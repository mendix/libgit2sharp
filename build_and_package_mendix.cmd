set debug=n
set version=1.0.1-mx

IF (%debug% == y) (	
	set debug=Debug
)
ELSE
(
	set debug=Release
)

dotnet build --configuration %debug%
del .\bin\LibGit2Sharp\%debug%\*.* /s /q /f
copy .\bin\LibGit2Sharp\%debug%\*.* /s .\nuget.package\Lib\
nuget pack .\nuget.package\Mendix_package.nuspec  -Version %version% -NoPackageAnalysis


