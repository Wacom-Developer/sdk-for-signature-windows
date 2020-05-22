@REM run a .JS script via cscript
@if [%1] == [] goto HELP
@if "%ProgramFiles(x86)%32BIT"=="32BIT" (
cscript /nologo %*
) else (
C:\Windows\SysWOW64\cscript /nologo %*
)

@goto END

:HELP
@echo. 
@echo Runs a .JS script file from cscript
@echo Example: Run-JS.bat CaptureImage.js
@echo. 
@echo Command line arguments are passed to the script
@echo Example: Run-JS.bat CaptureImage.js filename.png

:END
