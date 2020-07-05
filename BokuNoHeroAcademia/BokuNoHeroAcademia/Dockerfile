#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BokuNoHeroAcademia/BokuNoHeroAcademia.csproj", "BokuNoHeroAcademia/"]
RUN dotnet restore "BokuNoHeroAcademia/BokuNoHeroAcademia.csproj"
COPY . .
WORKDIR "/src/BokuNoHeroAcademia"
RUN dotnet build "BokuNoHeroAcademia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BokuNoHeroAcademia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BokuNoHeroAcademia.dll"]