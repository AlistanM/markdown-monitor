cd ..
git checkout master
git pull
cd src\.NET
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build