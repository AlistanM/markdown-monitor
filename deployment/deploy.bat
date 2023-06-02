cd ..
git stash create config_save
git checkout master
git pull
git stash pop config_save
cd src\.NET
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build
dotnet publish -r win-x64
cd ..\..\deployment