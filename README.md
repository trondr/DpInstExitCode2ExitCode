# DpInstExitCode2ExitCode
DpInstExitCode2ExitCode.exe translates the exit code from Dpinst.exe into a exit code that can be used in software distribution packages: Success (0), Error (1) or Reboot needed (3010)

## Usage

```
DpInstExitCode2ExitCode.exe <DpInst ExitCode>
```

## Example: Install-Package.cmd
```
Set ExitCode=0
pushd "%~dp0"

dpinst.exe /s /sa

Set DpInstExitCode=%errorlevel%
DpInstExitCode2ExitCode.exe %DpInstExitCode%

Set ExitCode=%errorlevel%
popd
EXIT /B %ExitCode%
```