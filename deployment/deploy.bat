set iisUI="UI"
set iisAPI="API"


cd ..
git stash create config_save
git checkout master
git pull
git stash pop config_save

"C:\Windows\System32\inetsrv\appcmd.exe" stop sites %iisUI%
"C:\Windows\System32\inetsrv\appcmd.exe" stop sites %iisAPI%

cd src\.NET
dotnet restore -s https://api.nuget.org/v3/index.json
dotnet build
timeout 3
dotnet publish -r win-x64
cd ..\go\api
go build -a -o .\bin\
copy /Y .\web.config .\bin\web.config

"C:\Windows\System32\inetsrv\appcmd.exe" start sites %iisUI%
"C:\Windows\System32\inetsrv\appcmd.exe" start sites %iisAPI%
cd ..\..\..\deployment