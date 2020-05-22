@echo.
@setlocal
@set APP=TestSigCapt
@set APP_SRC=src\com\wacom\sdk\sample\%APP%.java
@set APP_BIN=bin\com\wacom\sdk\sample\%APP%.class
@set APP_BIN_CLASS=com.wacom.sdk.sample.%APP%
@REM Point to ProgramFiles(x86) on 64bit Windows
@set PROGRAM_FILES=%ProgramFiles%
@set JAR_PATHS="%PROGRAM_FILES%\Common Files\WacomGSS\flsx.jar;%PROGRAM_FILES%\Common Files\WacomGSS\wgssLicenceJNI.jar;"
@set DLL_PATHS="%PROGRAM_FILES%\Common Files\WacomGSS"
@if exist %APP_BIN% del %APP_BIN%
@
@echo Compiling %APP% ...
@if not exist bin md bin
@"C:\Program Files\Java\jdk-10.0.1\bin\javac" -classpath bin;%JAR_PATHS% -d bin %APP_SRC%
@echo.
@if not exist %APP_BIN% goto END
@echo Run %APP% ...
@"C:\Program Files\Java\jdk-10.0.1\bin\java" -classpath bin;%JAR_PATHS% -Djava.library.path=%DLL_PATHS%  %APP_BIN_CLASS%
@goto END

:END
