@echo off

call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat"

C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild UnlockedStateProvider.sln /m /p:Configuration=Release

.nuget\nuget pack UnlockedStateProvider.Redis\UnlockedStateProvider.Redis.csproj -Prop Configuration=Release -IncludeReferencedProjects

@echo on
pause