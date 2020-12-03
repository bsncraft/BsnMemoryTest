@echo off
set DLLPATH=%~dp0BsnCraft.MemoryTest\bin\x86\Debug
set DBLPATH=%~dp0BsnMemoryTest
set EXEPATH=%~dp0Debug\x86
pushd "%DLLPATH%"
"%SYNERGYDE32%dbl\bin\gennet40" -o DBLPATH:DotNet.dbl BsnCraft.MemoryTest.dll
popd
xcopy "%DLLPATH%\*.*" "%EXEPATH%" /K /D /H /Y
