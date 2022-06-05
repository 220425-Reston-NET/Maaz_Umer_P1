

from mcr.microsoft.com/dotnet/sdk:6.0 as build 

#workdir docker instruction 
workdir /app

#copy docker instruction will let us copy files from this computer to put inside of the docker image 
# * asterisks is for wildcard that lets the computer scan for any files that ends with .sln in this case
copy *.sln ./
copy AppApi/*.csproj AppApi/
copy AppBL/*.csproj AppBL/
copy AppDL/*.csproj AppDL/
copy StoreModel/*.csproj StoreModel/
copy AppTest/*.csproj AppTest/

#Now copy the rest after setting up our project structure
copy . ./

#Restoring our bin and obj files
#run docker instruction will run a CLI command in the image
run dotnet build 

#It will create a publish folder that will hold all the information to be able to run your application 
run dotnet publish -c Release -o publish

#Multi-stage build in Docker 
#It allows us to have multiple ways to create our application 
#The first stage was all about buidling our application hence why we need an SDK
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app
copy --from=build /app/publish ./

#CMD docker instruction tells the docker engine how/where to run this application 
cmd ["dotnet", "AppApi.dll"]

#EXPOSE to port 80 
expose 80