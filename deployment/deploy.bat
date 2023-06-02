cd ..
git checkout master
git pull
cd src\.NET
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build
dotnet publish -r win-x64
cd ..\..\deployment