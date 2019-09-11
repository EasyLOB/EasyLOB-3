@ECHO RMDIR "bin" and "obj" directories
@ECHO Press any key to START or [CTRL][C] to STOP
@PAUSE
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S bin') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S obj') DO RMDIR /S /Q "%%G"
