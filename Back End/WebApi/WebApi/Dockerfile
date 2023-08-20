From mcr.microsoft.com/dotnet/sdk:6.0 as build
Workdir webApp

Expose 80
Expose 5024

#copy projects file
COPY ./*.csproj ./
RUN dotnet restore

# Copy All

COPY . .