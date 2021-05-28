FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY asp.netcore-app/*.csproj ./asp.netcore-app/
WORKDIR /app/asp.netcore-app
RUN dotnet restore

WORKDIR /app
COPY . .
WORKDIR /app/asp.netcore-app
RUN dotnet build

# publish the API
FROM build AS publish
WORKDIR /app/asp.netcore-app
RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=publish /app/asp.netcore-app/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "asp.netcore-app.dll"]
