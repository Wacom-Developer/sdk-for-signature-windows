@echo off
setlocal
set SRC=src\com\wacom\sdk\sample
set APP=SignatureCaptureSample
set APP_BIN=bin\com\wacom\sdk\sample\*.class
set APP_BIN_CLASS=com.wacom.sdk.sample.%APP%

set SDKFOLDER=%CommonProgramFiles%\WacomGSS
if not exist "%SDKFOLDER%" (
  echo Please install Wacom Ink SDK for Signature 
  goto END
)

set JAR_FILES=%SDKFOLDER%\wgssSignatureCapture.jar;%SDKFOLDER%\wgssJNI.jar;%SDKFOLDER%\flsx.jar;%SDKFOLDER%\wgssLicenceJNI.jar;
set DLL_PATHS="%SDKFOLDER%"

if exist %APP_BIN% del %APP_BIN%

echo Compiling %APP% ...
if not exist bin md bin
JAVAC -classpath "bin;%JAR_FILES%" -d bin %SRC%\*.java
echo.
if not exist %APP_BIN% goto END

echo Run %APP% ...
JAVA -classpath "bin;%JAR_FILES%" -Djava.library.path=%DLL_PATHS%  %APP_BIN_CLASS%
goto END

:END
