/*************************************************************************
  TestWizSignCapt.cpp

  C++ Signature Capture using Wizard Control

  Displays a form with a button to start signature capture using the Wizard script
  The captured signature is encoded in an image file which is displayed on the form

  Copyright (c) 2015 Wacom GmbH. All rights reserved.

***************************************************************************/
#include <windows.h>
#include <strsafe.h>
#include <comdef.h>
#include <new>

#include "resource.h"

#import "progid:Florentis.SigCtl"         named_guids rename_namespace("sigctl")
#import "progid:Florentis.WizCtl"         named_guids no_namespace 

template<class T>
class simple_IDispatch : public T
{
protected:
  ULONG  m_refCount;
public:
  simple_IDispatch() : m_refCount(1) {}
  virtual ~simple_IDispatch() {}

  // IUnknown
  STDMETHOD(QueryInterface)(IID const & iid, LPVOID * pvoid) override
  {
    if (!pvoid)
      return E_POINTER;
    *pvoid = nullptr;

    HRESULT hr;
    if (iid == __uuidof(T))
    {
      *pvoid = static_cast<T *>(this);
      AddRef();
      hr = S_OK;
    }
    else if (iid == __uuidof(IDispatch))
    {
      *pvoid = static_cast<IDispatch *>(this);
      AddRef();
      hr = S_OK;
    }
    else if (iid == __uuidof(IUnknown))
    {
      *pvoid = static_cast<IUnknown *>(this);
      AddRef();
      hr = S_OK;
    }
    else
    {
      hr = E_NOINTERFACE;
    }
    return hr;
  }

  ULONG _stdcall AddRef() override { return (ULONG)InterlockedIncrement(&m_refCount); }
  ULONG _stdcall Release() override { ULONG refCount = InterlockedDecrement(&m_refCount); if (!refCount) { delete this; } return refCount; }

  // IDispatch
  STDMETHOD(GetTypeInfoCount)(UINT*) override { return E_NOTIMPL; }
  STDMETHOD(GetTypeInfo)(UINT, LCID, ITypeInfo**) override { return E_NOTIMPL; }
  STDMETHOD(GetIDsOfNames)(IID const &, LPOLESTR*, UINT, LCID, DISPID *) override { return E_NOTIMPL; }
  //STDMETHOD(Invoke)(DISPID,IID const &,LCID,WORD,DISPPARAMS *,VARIANT*,EXCEPINFO *,UINT*) override;
};


class myEventHandler : public simple_IDispatch<_IWizCtlEvents>
{
public:
  // IDispatch
  STDMETHOD(Invoke)(DISPID, IID const &, LCID, WORD, DISPPARAMS *, VARIANT*, EXCEPINFO *, UINT*) override;

  // custom
  virtual HRESULT handle_PadEvent(
    IDispatch * WizCtl,
    _bstr_t id,
    const _variant_t & EventType) = 0;
};


STDMETHODIMP myEventHandler::Invoke(DISPID dispId, IID const &, LCID, WORD wFlags, DISPPARAMS* pDispParams, VARIANT*, EXCEPINFO*, UINT*)
{
  //if (wFlags == DISPATCH_METHOD && pDispParams && pDispParams->cArgs == 3 && dispId == 1 && pDispParams->rgvarg[0].vt == VT_DISPATCH && pDispParams->rgvarg[1].vt == VT_BSTR)
  if (wFlags == DISPATCH_METHOD && pDispParams && pDispParams->cArgs == 3 && dispId == 0 && pDispParams->rgvarg[1].vt == VT_BSTR)
  {
    return handle_PadEvent(pDispParams->rgvarg[0].pdispVal, pDispParams->rgvarg[1].bstrVal, pDispParams->rgvarg[2]);
  }
  return DISP_E_MEMBERNOTFOUND;
}

struct tPad
{
  char* model;
  IFontDispPtr textFont;
  IFontDisp* buttonFont;
  IFontDisp* sigLineFont;
  int signatureLineY;
  int whoY;
  int whyY;
  int buttonWidth;

  tPad(char* model, int signatureLineY, int whoY, int whyY,
    int textFontSize, int buttonFontSize, int signLineSize, int buttonWith)
  {
    this->model = model;
    this->signatureLineY = signatureLineY;
    this->whoY = whoY;
    this->whyY = whyY;
    this->buttonWidth = buttonWith;

    FONTDESC fontDesc1;
    ::memset(&fontDesc1, 0, sizeof(FONTDESC));
    fontDesc1.cbSizeofstruct = sizeof(FONTDESC);
    fontDesc1.lpstrName = L"Verdana";
    fontDesc1.cySize.int64 = textFontSize * 10000;
    ::OleCreateFontIndirect(&fontDesc1, IID_IFontDisp, (void**)&(this->textFont));

    FONTDESC fontDesc2;
    ::memset(&fontDesc2, 0, sizeof(FONTDESC));
    fontDesc2.cbSizeofstruct = sizeof(FONTDESC);
    fontDesc2.lpstrName = L"Verdana";
    fontDesc2.cySize.int64 = buttonFontSize * 10000;
    ::OleCreateFontIndirect(&fontDesc2, IID_IFontDisp, (void**)&(this->buttonFont));

    FONTDESC fontDesc3;
    ::memset(&fontDesc3, 0, sizeof(FONTDESC));
    fontDesc3.cbSizeofstruct = sizeof(FONTDESC);
    fontDesc3.lpstrName = L"Verdana";
    fontDesc3.cySize.int64 = signLineSize * 10000;
    ::OleCreateFontIndirect(&fontDesc3, IID_IFontDisp, (void**)&(this->sigLineFont));
  }

};

struct DlgData : myEventHandler
{
  sigctl::ISigCtl2Ptr pSigCtl;
  IWizCtl2Ptr pWizCtl;
  bool isCheck;

  tPad* thePad;
  HWND hWnd;

  void printText(LPCSTR text);
  void handleException(_com_error const & ex);
  void handleException(std::exception const & ex);

  HRESULT handle_PadEvent(IDispatch * WizCtl, _bstr_t id, const _variant_t & EventType) override;
  void step1();
  void step2();
  void startWizard();
  void scriptCompleted();
  void scriptCancelled();
  void displayImage(LPCSTR pszFilename);
  void closeWizard();
};

HINSTANCE hInst;
bool isImage = false;
bool scriptIsRunning = false;

DlgData * GetDlgData(HWND hWnd)
{
  return reinterpret_cast<DlgData *>(GetWindowLongPtr(hWnd, DWLP_USER));
}

static void write(LPCSTR pszFilename, void HUGEP * p, unsigned long num)
{
  HANDLE hFile = CreateFile(pszFilename, GENERIC_WRITE, FILE_SHARE_READ, 0, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);
  if (hFile != INVALID_HANDLE_VALUE)
  {
    DWORD dwBytesWritten;
    WriteFile(hFile, p, num, &dwBytesWritten, 0);
    CloseHandle(hFile);
  }
}

static void write(LPCSTR pszFilename, VARIANT * v)
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

void DlgData::displayImage(LPCSTR pszFilename)
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

void DlgData::closeWizard()
{
  printText("closeWizard\r\n");
  scriptIsRunning = false;
  pWizCtl->Reset();
  pWizCtl->Display();
  pWizCtl->PadDisconnect();
  pWizCtl->SetEventHandler(NULL);
}

void DlgData::scriptCompleted()
{
  printText("scriptCompleted\r\n");
  sigctl::ISigObj3Ptr sigObj = pSigCtl->Signature;
  if (sigObj->IsCaptured)
  {
    sigObj->PutExtraData(L"AdditonalData", L"C++ Wizard test: Additional data");
    LPCSTR filename = "sign1.bmp";
    _bstr_t MimeType(L"image/bmp");
    _variant_t v = sigObj->RenderBitmap(_bstr_t(), 200, 150, MimeType, 0.7f, 0x00000000, 0x00ffffff, 4, 4, (sigctl::RBFlags)(sigctl::RenderOutputBinary | sigctl::RenderColor24BPP | sigctl::RenderColorAntiAlias | sigctl::RenderEncodeData));
    write("sign1.bmp", &v);
    isImage = true;
    InvalidateRect(hWnd, 0, 0);
    closeWizard();
  }
}
void DlgData::scriptCancelled()
{
  printText("scriptCancelled\r\n");
  closeWizard();
}

void DlgData::printText(LPCSTR text)
{
  SendMessage(GetDlgItem(hWnd, IDC_EDIT1), EM_REPLACESEL, 0, (LPARAM)text);
}

void DlgData::handleException(_com_error const & ex)
{
  CHAR    msg[1024];
  _bstr_t desc = ex.Description();

  if (!desc)
  {
    desc = ex.ErrorMessage();
  }
  StringCbPrintfA(msg, sizeof(msg), "COM Error 0x%x: %S", ex.Error(), desc.GetBSTR());

  printText(msg);
}

void DlgData::handleException(std::exception const & ex)
{
  CHAR msg[1024];
  StringCbPrintfA(msg, sizeof(msg), "Exception: %s", ex.what());

  printText(msg);
}


HRESULT DlgData::handle_PadEvent(
  IDispatch * WizCtl,
  _bstr_t id,
  const _variant_t & EventType)
{
  try
  {
    if (0 == wcscmp(id, L"Ok"))
    {
      scriptCompleted();
    }
    else if (0 == wcscmp(id, L"Cancel"))
    {
      scriptCancelled();
    }
    else if (0 == wcscmp(id, L"Next"))
    {
      if (isCheck)
        step2();
    }
    else if (0 == wcscmp(id, L"Check"))
    {
      isCheck = !isCheck;
    }
    else
    {
      printText("Unexpected pad event\r\n");
    }
    return S_OK;
  }
  catch (_com_error const & exCOM)
  {
    handleException(exCOM);
  }
  catch (std::exception const & exStd)
  {
    handleException(exStd);
  }
  return E_FAIL;
}

void DlgData::step1()
{
  pWizCtl->Reset();

  // insert checkbox
  pWizCtl->PutFont(thePad->textFont);
  pWizCtl->AddObject(ObjectCheckbox, "Check", "centre", "middle", "I have read and I accept the terms and conditions", 2);

  // insert the buttons
  pWizCtl->PutFont(thePad->buttonFont);
  pWizCtl->AddObject(ObjectButton, "Cancel", "left", "bottom", "Cancel", thePad->buttonWidth);
  pWizCtl->AddObject(ObjectButton, "Next", "right", "bottom", "Next", thePad->buttonWidth);

  pWizCtl->SetEventHandler(this);
  pWizCtl->Display();
}

void DlgData::step2()
{
  pWizCtl->Reset();

  // insert message
  pWizCtl->PutFont(thePad->textFont);
  pWizCtl->AddObject(ObjectText, "txt", "centre", "top", "Please sign below...", 0);

  // insert a signature line
  pWizCtl->PutFont(thePad->sigLineFont);
  if (strcmp(thePad->model, "STU-300") == 0)
  {
    pWizCtl->AddObject(ObjectText, "txt", "left", thePad->signatureLineY, "X..............................", 0);
  }
  else
  {
    pWizCtl->AddObject(ObjectText, "txt", "centre", thePad->signatureLineY, "X..............................", 0);
  }

  // insert the signature control
  pWizCtl->PutFont(thePad->textFont);
  pWizCtl->AddObject(ObjectSignature, "Sig", 0, 0, _variant_t(pSigCtl->Signature.GetInterfacePtr()));

  // provide who and why for sig capture
  pWizCtl->AddObject(ObjectText, "who", "right", thePad->whoY, _variant_t(L"J Smith"));
  pWizCtl->AddObject(ObjectText, "why", "right", thePad->whyY, _variant_t(L"I ceritify that the information is correct"));

  // insert the buttons
  pWizCtl->PutFont(thePad->buttonFont);
  if (strcmp(thePad->model, "STU-300") == 0)
  {
    pWizCtl->AddObject(ObjectButton, "Cancel", "right", "top", "Cancel", thePad->buttonWidth);
    pWizCtl->AddObject(ObjectButton, "Clear", "right", "middle", "Clear", thePad->buttonWidth);
    pWizCtl->AddObject(ObjectButton, "Ok", "right", "bottom", "Ok", thePad->buttonWidth);
  }
  else
  {
    pWizCtl->AddObject(ObjectButton, "Cancel", "left", "bottom", "Cancel", thePad->buttonWidth);
    pWizCtl->AddObject(ObjectButton, "Clear", "center", "bottom", "Clear", thePad->buttonWidth);
    pWizCtl->AddObject(ObjectButton, "Ok", "right", "bottom", "Ok", thePad->buttonWidth);
  }

  pWizCtl->SetEventHandler(this);
  pWizCtl->Display();
}

void DlgData::startWizard()
{
  printText("startWizard\r\n");
  if (pWizCtl->PadConnect())
  {
    scriptIsRunning = true;
    switch (pWizCtl->PadWidth)
    {
    case 396:
      thePad = new(std::nothrow) tPad("STU-300", 60, 200, 200, 8, 8, 16, 70); // 396 x 100
      printText("STU-300\r\n");
      break;
    case 640:
      thePad = new(std::nothrow) tPad("STU-500", 300, 360, 390, 16, 22, 32, 110); // 640 x 800
      printText("STU-500\r\n");
      break;
    case 800:
      thePad = new(std::nothrow) tPad("STU-520/530/540", 300, 360, 390, 16, 22, 32, 110); // 800 x 480
      printText("STU-520, STU-530 or STU-540\r\n");
      break;
    case 320:
      thePad = new(std::nothrow) tPad("STU-430", 100, 130, 150, 10, 12, 16, 110); // 320 x 200
      printText("STU-430\r\n");
      break;
    default:
      printText("No compatible device fount\r\n");
    }
    step1();
  }
  else
    printText("Unable to connect to tablet\r\n");
}

INT_PTR CALLBACK DlgProc(HWND hWnd, UINT uMessage, WPARAM wParam, LPARAM lParam)
{
  try
  {
    switch (uMessage)
    {
    case WM_PAINT:
      if (isImage)
      {
        if (DlgData * dlgData = GetDlgData(hWnd))
          dlgData->displayImage("sign1.bmp");
      }
      break;

    case WM_CLOSE:
      if (DlgData * dlgData = GetDlgData(hWnd))
      {
        if (scriptIsRunning)
        {
          dlgData->scriptCancelled();
        }
      }
      EndDialog(hWnd, 0);
      break;

    case WM_DESTROY:
    {
      delete GetDlgData(hWnd);
    }
    break;

    case WM_INITDIALOG:
    {
      DlgData * dlgData = new(std::nothrow) DlgData;
      dlgData->hWnd = hWnd;
      SetWindowLongPtr(hWnd, DWLP_USER, reinterpret_cast<LONG_PTR>(dlgData));

      HRESULT hr = dlgData->pWizCtl.CreateInstance(__uuidof(WizCtl));
      dlgData->pSigCtl.CreateInstance(__uuidof(sigctl::SigCtl));

      dlgData->pWizCtl->Licence = L"<<licence>>";
    }
    break;

    case WM_COMMAND:
      switch (LOWORD(wParam))
      {
      case IDC_SIGN:
        if (DlgData * dlgData = GetDlgData(hWnd))
        {
          dlgData->printText("Sign...\r\n");
          dlgData->isCheck = false;
          if (!scriptIsRunning)
            dlgData->startWizard();
          else
            dlgData->printText("Script is already running\r\n");
        }
        return TRUE;

      case IDC_CANCEL:
        if (DlgData * dlgData = GetDlgData(hWnd))
        {
          dlgData->printText("Cancel...\r\n");
          if (scriptIsRunning)
          {
            dlgData->scriptCancelled();
          }
          else
          {
            dlgData->printText("Script is not running\r\n");
          }
        }
        return TRUE;
      }
      break;
    }

  }
  catch (_com_error const & exCOM)
  {
    if (DlgData * dlgData = GetDlgData(hWnd))
      dlgData->handleException(exCOM);    
  }
  catch (std::exception const & exStd)
  {
    if (DlgData * dlgData = GetDlgData(hWnd))
      dlgData->handleException(exStd);    
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