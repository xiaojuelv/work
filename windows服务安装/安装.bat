%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe YuwellWinService.exe
Net Start YuwellWinService
sc config YuwellWinService start= auto