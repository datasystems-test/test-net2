 # syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY ../CRUD-NETCore-TDD/bin/Release/netcoreapp3.1/publish App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "CRUD-NETCore-TDD.dll"]