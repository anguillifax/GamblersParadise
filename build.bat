@echo off
set editor="C:\Program Files\Unity\Hub\Editor\2021.1.10f1\Editor\Unity.exe"
set project=.
set name=GamblersParadise

set cmd=%editor% -quit -batchmode -projectPath %project%

echo Building for Windows 64
%cmd% -buildWindows64Player "Build/win64/%name%.exe"

echo Building for OSX
%cmd% -buildOSXUniversalPlayer "Build/osx/%name%"

echo Done.