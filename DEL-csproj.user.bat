@ECHO DEL "*.csproj.user" files
@ECHO Press any key to START or [CTRL][C] to STOP
@PAUSE
FOR /F "tokens=*" %%G IN ('DIR /B /S *.csproj.user') DO DEL /Q "%%G"
