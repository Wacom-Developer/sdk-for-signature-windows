/*************************************************************************
  TestSignCapt.cpp

  C++ Signature Capture

  Displays a form with a button to start signature capture
  The captured signature is encoded in an image file which is displayed on the form

  Copyright (c) 2015 Wacom GmbH. All rights reserved.

***************************************************************************/
#include <windows.h>
#include <strsafe.h>
#include <comdef.h>
#include <new>

#include "resource.h"

#import "progid:Florentis.SigCtl"         named_guids no_namespace
#import "progid:Florentis.DynamicCapture" named_guids no_namespace

void HandleException(HWND hWnd, _com_error const & ex)
{
  CHAR    msg[1024];
  _bstr_t desc = ex.Description();

  if (!desc)
  {
    desc = ex.ErrorMessage();
  }
  StringCbPrintfA(msg, sizeof(msg), "COM Error 0x%x: %S", ex.Error(), desc.GetBSTR());

  MessageBoxA(hWnd, msg, NULL, MB_ICONEXCLAMATION | MB_OK);
}

void HandleException(HWND hWnd, std::exception const & ex)
{
  CHAR msg[1024];
  StringCbPrintfA(msg, sizeof(msg), "Exception: %s", ex.what());

  MessageBoxA(hWnd, msg, NULL, MB_ICONEXCLAMATION | MB_OK);
}


struct DlgData
{
  ISigCtl2Ptr pSigCtl;
};

HINSTANCE hInst;
bool isImage = false;

DlgData * GetDlgData(HWND hWnd)
{
  return reinterpret_cast<DlgData *>(GetWindowLongPtr(hWnd, DWLP_USER));
}

static void write(PCWSTR pszFilename, void HUGEP * p, unsigned long num)
{
  HANDLE hFile = CreateFile(pszFilename, GENERIC_WRITE, FILE_SHARE_READ, 0, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);
  if (hFile != INVALID_HANDLE_VALUE)
  {
    DWORD dwBytesWritten;
    WriteFile(hFile, p, num, &dwBytesWritten, 0);
    CloseHandle(hFile);
  }
}

static void write(PCWSTR pszFilename, VARIANT * v)
{
  if (v->vt == (VT_UI1 | VT_ARRAY) && V_ARRAY(v)->cDims == 1)
  {
    void HUGEP * p = 0;
    HRESULT hr = SafeArrayAccessData(V_ARRAY(v), &p);
    if (SUCCEEDED(hr))
    {
      write(pszFilename, p, V_ARRAY(v)->rgsabound[0].cElements);

      SafeArrayUnaccessData(V_ARRAY(v));
    }
  }
}

static void displayImage(PCWSTR pszFilename, HWND hWnd)
{
  HBITMAP hBitmap = (HBITMAP)LoadImage(hInst, pszFilename, IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE);
  PAINTSTRUCT ps;
  HDC hdc;
  BITMAP bitmap;
  HDC hdcMem;
  HGDIOBJ oldBitmap;

  hdc = BeginPaint(GetDlgItem(hWnd, IDC_PICTURE), &ps);

  hdcMem = CreateCompatibleDC(hdc);
  oldBitmap = SelectObject(hdcMem, hBitmap);

  GetObject(hBitmap, sizeof(bitmap), &bitmap);
  BitBlt(hdc, 0, 0, bitmap.bmWidth, bitmap.bmHeight, hdcMem, 0, 0, SRCCOPY);

  SelectObject(hdcMem, oldBitmap);
  DeleteDC(hdcMem);

  EndPaint(GetDlgItem(hWnd, IDC_PICTURE), &ps);

}

static void printText(HWND hWnd, PCWSTR text)
{
  SendMessage(GetDlgItem(hWnd, IDC_EDIT1), EM_REPLACESEL, 0, (LPARAM)text);
}

INT_PTR CALLBACK DlgProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam)
{
  try
  {
    switch (uMessage)
    {
    case WM_PAINT:
    {
      if (isImage)
        displayImage(L"sign1.bmp", hWnd);
    }
    break;

    case WM_CLOSE:
    {
      EndDialog(hWnd, 0);
    }
    break;

    case WM_DESTROY:
    {
      delete GetDlgData(hWnd);
    }
    break;

    case WM_INITDIALOG:
    {
      DlgData * dlgData = new(std::nothrow) DlgData;
      SetWindowLongPtr(hWnd, DWLP_USER, reinterpret_cast<LONG_PTR>(dlgData));

      HRESULT hr = dlgData->pSigCtl.CreateInstance(__uuidof(SigCtl));
      ISigCtl3Ptr sigCtl3 = dlgData->pSigCtl;
      sigCtl3->Licence = L"<<license>>";
    }
    break;

    case WM_COMMAND:
      switch (LOWORD(wParam))
      {
      case IDC_SIGN:
        printText(hWnd, L"btnSign was pressed\r\n");
        if (DlgData * dlgData = GetDlgData(hWnd))
        {
          IDynamicCapturePtr pDynamicCapture(__uuidof(DynamicCapture));

          _bstr_t Who(L"Who");
          _bstr_t Why(L"Why");

          DynamicCaptureResult result = pDynamicCapture->Capture(dlgData->pSigCtl, Who, Why, 0, 0);

          if (result == DynCaptOK) {
            printText(hWnd, L"signature captured succesfully\r\n");
            ISigObj3Ptr sigObj = dlgData->pSigCtl->Signature;
            sigObj->PutExtraData(L"AdditonalData", L"C++ test: Additional data");
            PCWSTR filename = L"sign1.bmp";
            _bstr_t MimeType(L"image/bmp");
            _variant_t v = sigObj->RenderBitmap(_bstr_t(), 200, 150, MimeType, 0.7f, 0x00000000, 0x00ffffff, 4, 4, (RBFlags)(RenderOutputBinary | RenderColor24BPP | RenderColorAntiAlias | RenderEncodeData));
            write(filename, &v);
            isImage = true;
            InvalidateRect(hWnd, 0, 0);
          }
          else {
            switch (result)
            {
            case DynCaptCancel:
              printText(hWnd, L"signature cancelled\r\n");
              break;
            case DynCaptError:
              printText(hWnd, L"no capture service available\r\n");
              break;
            case DynCaptPadError:
              printText(hWnd, L"signing device error\r\n");
              break;
            }
          }
        }
      }
      return TRUE;
    }
  }
  catch (_com_error const & exCOM)
  {
    HandleException(hWnd, exCOM);
  }
  catch (std::exception const & exStd)
  {
    HandleException(hWnd, exStd);
  }

  return FALSE;
}

int PASCAL WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int)
{
  hInst = hInstance;
  HRESULT hr = CoInitializeEx(0, COINIT_APARTMENTTHREADED);
  if (SUCCEEDED(hr))
  {
    int i = DialogBoxParam(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), nullptr, DlgProc, 0);
    CoUninitialize();
  }
  return 1;
}