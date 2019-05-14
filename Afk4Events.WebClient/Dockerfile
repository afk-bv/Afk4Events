FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["Afk4Events.WebClient/Afk4Events.WebClient.csproj", "Afk4Events.WebClient/"]
RUN dotnet restore "Afk4Events.WebClient/Afk4Events.WebClient.csproj"
COPY . .
WORKDIR "/src/Afk4Events.WebClient"
RUN dotnet build "Afk4Events.WebClient.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Afk4Events.WebClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Afk4Events.WebClient.dll"]
