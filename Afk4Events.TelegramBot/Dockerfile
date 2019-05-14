FROM mcr.microsoft.com/dotnet/core/runtime:3.0-alpine as runtime
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS sdk
WORKDIR /src
COPY [ "Afk4Events.TelegramBot/Afk4Events.TelegramBot.csproj", "Afk4Events.TelegramBot/" ]
RUN dotnet restore "Afk4Events.TelegramBot/Afk4Events.TelegramBot.csproj"
COPY . .
WORKDIR "/src/Afk4Events.TelegramBot"
RUN dotnet build "Afk4Events.TelegramBot.csproj" -c Release -o /app


FROM sdk AS publish
RUN dotnet publish "Afk4Events.TelegramBot.csproj" -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT [ "dotnet", "Afk4Events.TelegramBot.dll" ]
