echo off
echo "首先发布该Service项目，生成publish文件夹，然后到publish文件夹下双击执行该bat文件，即可发布服务到dapr"
echo **********************************************************************************************
cd /d %~dp0
dapr stop Dapr-Test
timeout /nobreak /t 3
dapr run --app-id Dapr-Test --app-port 62020 -- dotnet Dapr.Test.dll --urls "http://*:62020"