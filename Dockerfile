from mcr.microsoft.com/dotnet/sdk:6.0 as build 

#workdir docker instruction 
workdir /app

#Remove the copy instruction here
#copy /publish ./

#Change the CMD to entrypoint
entrypoint ["dotnet", "AppApi.dll"]

#EXPOSE to port 5000
expose 5000

#We need to change our ASP.NET application to also start listening to 5000 port
env ASPNETCORE_URLS=https://+:5000