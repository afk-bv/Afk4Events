FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["Afk4Events.Api/Afk4Events.Api.csproj", "Afk4Events.Api/"]
RUN dotnet restore "Afk4Events.Api/Afk4Events.Api.csproj"
COPY . .
WORKDIR "/src/Afk4Events.Api"
RUN dotnet build "Afk4Events.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Afk4Events.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Afk4Events.Api.dll"]