del build.log
mkdir ..\out

devenv.exe ..\src\Transhipment.sln /build Release /out build.log
..\tools\nuget\NuGet.exe pack Transhipment.nuspec -o ..\out