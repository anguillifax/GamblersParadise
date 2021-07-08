@echo off

set suffix=-post

CALL :Push win64
CALL :Push osx
CALL :Push web

EXIT

:Push
echo Pushing `Build/%~1` as %~1%suffix%
butler push "Build/%~1" dsaname/gamblers-paradise:%~1%suffix%
EXIT /B 0