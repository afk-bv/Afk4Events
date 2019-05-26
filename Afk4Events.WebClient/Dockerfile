FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview5 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

WORKDIR /src
COPY ["Afk4Events.WebClient/Afk4Events.WebClient.csproj", "Afk4Events.WebClient/"]
RUN dotnet restore "Afk4Events.WebClient/Afk4Events.WebClient.csproj"
COPY . .
WORKDIR "/src/Afk4Events.WebClient"
ENTRYPOINT ["dotnet", "run"]
