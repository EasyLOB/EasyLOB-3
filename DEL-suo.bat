@ECHO DEL ".suo" files
@ECHO Press any key to START or [CTRL][C] to STOP
@PAUSE
FOR /F "tokens=*" %%G IN ('DIR /AH /B /S .suo') DO DEL /AH /Q "%%G"
