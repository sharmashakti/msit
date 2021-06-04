FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY src/StatlerWaldorfCorp.TeamService/*.csproj ./src/StatlerWaldorfCorp.TeamService/
WORKDIR /app/src/StatlerWaldorfCorp.TeamService
RUN dotnet restore

WORKDIR /app
COPY test/StatlerWaldorfCorp.TeamService.Tests/*.csproj ./test/StatlerWaldorfCorp.TeamService.Tests/
WORKDIR /app/test/StatlerWaldorfCorp.TeamService.Tests
RUN dotnet restore

WORKDIR /app
COPY . .
WORKDIR /app/src/StatlerWaldorfCorp.TeamService
RUN dotnet build
WORKDIR /app/test/StatlerWaldorfCorp.TeamService.Tests
RUN dotnet build

# run the unit tests
FROM build AS test
WORKDIR /app/test/StatlerWaldorfCorp.TeamService.Tests
RUN dotnet build
RUN dotnet test --results-directory /testresults --logger:trx

# publish the API
FROM build AS publish
WORKDIR /app/src/StatlerWaldorfCorp.TeamService
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
#COPY --from=test /app/test/StatlerWaldorfCorp.TeamService.Tests/testresults/ ./
COPY --from=publish /app/src/StatlerWaldorfCorp.TeamService/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "StatlerWaldorfCorp.TeamService.dll"]
