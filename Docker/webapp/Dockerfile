FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY webapp/webapp.csproj webapp/
RUN dotnet restore webapp/webapp.csproj
COPY . .
WORKDIR /src/webapp
RUN dotnet build webapp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish webapp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webapp.dll"]
