@echo off
setlocal
set APP=SignatureCaptureSample
set SRC=src\com\wacom\sdk\sample
set BIN=bin\com\wacom\sdk\sample
set APP_SRC=%SRC%\%APP%.java
set APP_BIN=%BIN%\%APP%.class
set APP_BIN_CLASS=com.wacom.sdk.sample.%APP%

set SDKFOLDER=%CommonProgramFiles%\WacomGSS\
REM if not exist "%SDKFOLDER%" (
REM   echo Please install Wacom Ink SDK for Signature 
REM   goto END
REM )

REM set JAR_FILES="%SDKFOLDER%\wgssSignatureCapture.jar;%SDKFOLDER%\flsx.jar;%SDKFOLDER%\wgssLicenceJNI.jar;"
REM set DLL_PATHS="%SDKFOLDER%"

@set JAR_FILES="C:\Dev\Bitbucket\wgss-signature-capture\build\x64\v143\Debug\wgssSignatureCapture.jar;C:\Dev\Bitbucket\signature-sdk-win\Libraries\sx\build\x64\v143\Debug\flsx.jar;C:\Dev\Bitbucket\signature-sdk-win\Libraries\lc2\build\x64\v143\Debug\wgssLicenceJNI.jar;"
@set DLL_PATHS="C:\Dev\Bitbucket\wgss-signature-capture\build\x64\v143\Debug;C:\Dev\Bitbucket\signature-sdk-win\Libraries\sx\build\x64\v143\Debug;C:\Dev\Bitbucket\wgss-licensing\build\x64\v143\Debug"

if exist %APP_BIN% del %APP_BIN%

echo Compiling %APP% ...
if not exist bin md bin
JAVAC -classpath bin;%JAR_FILES% -d bin %SRC%\*.java
echo.
if not exist %APP_BIN% goto END

echo Run %APP% ...
JAVA -classpath bin;%JAR_FILES% -Djava.library.path=%DLL_PATHS%  %APP_BIN_CLASS%
goto END

:END
