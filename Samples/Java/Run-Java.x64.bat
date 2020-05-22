@setlocal
@if [%1] == [] goto HELP
@REM remove the .java extension using %~n1% in place of %1%
@set APP=%~n1%
@set APP_SRC=%APP%.java
@set APP_BIN=bin\%APP%.class
@if not exist bin md bin
@if exist %APP_BIN% del %APP_BIN%
@set PROGRAM_FILES=%ProgramFiles%
@set JAR_FILES="%PROGRAM_FILES%\Common Files\WacomGSS\flsx.jar;%PROGRAM_FILES%\Common Files\WacomGSS\wgssLicenceJNI.jar;"
@set DLL_PATHS="%PROGRAM_FILES%\Common Files\WacomGSS"
@
@echo Compiling %APP% ...
@javac -classpath %JAR_FILES% -d bin %APP_SRC%
@echo.
@if not exist %APP_BIN% goto END
@echo Run %APP_SRC% ...
@REM skip %1% arg
@java -classpath %JAR_FILES%.\bin -Djava.library.path=%DLL_PATHS% %APP% %2 %3 %4 %5 %6 %7
@goto END

:HELP
@echo. 
@echo Compiles then runs a .java application
@echo (Folder bin is created for the compiled .class file)
@echo Example: Run-Java.bat CaptureImage.java
@echo. 
@echo Command line arguments are passed to the java app
@echo Example: Run-Java.bat CaptureImage.java filename.png

:END
