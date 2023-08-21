From mcr.microsoft.com/dotnet/sdk:6.0 as build
Workdir webapp

Expose 80
Expose 5024

#copy projects file
COPY ./*.csproj ./
RUN dotnet restore

# Copy All
COPY . .
Run dotnet publish -c Release -o Dependencias

#Build Image
From mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /webapp
copy --from=build /webapp/out .
ENTRYPOINT ["dotnet","WebApi.Aplication.dll"]
