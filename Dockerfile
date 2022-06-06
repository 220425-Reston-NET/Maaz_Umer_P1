#Another stage that is all about running the application or how to run
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

#workdir docker instruction 
workdir /app

#Remove the copy instruction here

#Copy the publish folder into the image
copy /publish ./

#Change the CMD to entrypoint
entrypoint ["dotnet", "AppApi.dll"]

#EXPOSE to port 5000
expose 5000

#We need to change our ASP.NET application to also start listening to 5000 port
env ASPNETCORE_URLS=http://+:5000