 # syntax=docker/dockerfile:1
  FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY \CRUD-NETCore-TDD.Infra\bin\Release\netcoreapp3.1\publish
  COPY \CRUD-NETCore-TDD\bin\Release\netcoreapp3.1\publish
  WORKDIR /App
  ENTRYPOINT ["dotnet", "CRUD-NETCore-TDD.dll"]