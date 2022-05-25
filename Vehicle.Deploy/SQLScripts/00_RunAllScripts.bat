cd %~dp0
for %%i in (*.sql) do sqlcmd /s "." -E -i"%%i"
pause