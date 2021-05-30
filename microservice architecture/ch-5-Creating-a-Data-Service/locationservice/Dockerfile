FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY src/StatlerWaldorfCorp.LocationService/*.csproj ./src/StatlerWaldorfCorp.LocationService/
WORKDIR /app/src/StatlerWaldorfCorp.LocationService
RUN dotnet restore


WORKDIR /app
COPY . .
WORKDIR /app/src/StatlerWaldorfCorp.LocationService
RUN dotnet build

# publish the API
FROM build AS publish
WORKDIR /app/src/StatlerWaldorfCorp.LocationService
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
#COPY --from=test /app/test/StatlerWaldorfCorp.LocationService.Tests/testresults/ ./
COPY --from=publish /app/src/StatlerWaldorfCorp.LocationService/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "StatlerWaldorfCorp.LocationService.dll"]
