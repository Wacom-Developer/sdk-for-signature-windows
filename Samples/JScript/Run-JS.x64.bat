@REM run a .JS script via cscript
@if [%1] == [] goto HELP

cscript /nologo %*




@goto END

:HELP
@echo. 
@echo Runs a .JS script file from cscript
@echo Example: Run-JS.bat CaptureImage.js
@echo. 
@echo Command line arguments are passed to the script
@echo Example: Run-JS.bat CaptureImage.js filename.png

:END
