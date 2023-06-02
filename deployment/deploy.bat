set iisSiteName="markdown-monitor"


cd ..
git stash create config_save
git checkout master
git pull
git stash pop config_save
cd src\.NET
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build
"C:\Windows\System32\inetsrv\appcmd.exe" stop sites %iisSiteName%
dotnet publish -r win-x64
"C:\Windows\System32\inetsrv\appcmd.exe" start sites %iisSiteName%
cd ..\..\deployment