# Afk4Events Telegram Bot

## Compilation
`Afk4Events.TelegramBot` is a .NET Core 3.0 application. Build and run it via the provided
`Dockerfile` or compile and run it directly (requires .NET Core SDK 3.0).

## Installation

The Afk4Events bot makes use of Telegram's bot functionality and a functional, up-and-running instance of `Afk4Events.API`.

## Usage

In order to connect the Afk4Events.TelegramBot application to an actual Telegram Bot,
it is necessary to provide it with your Telegram bot API Token. For more information on how
to generate such a key, please read through [Telegram's Documentation on the topic.](https://core.telegram.org/bots#3-how-do-i-create-a-bot) 
Afk4Events.TelegramBot expects the API Token to be provided by the environment variable `AFK4EVENTS_BOT_TOKEN`. 
**Without this token, the bot will not work.**

## Running the Bot (Direct)

```bash
$ AFK4EVENTS_BOT_TOKEN=<Your>:<BotToken>
$ dotnet run
```

## Running via Docker
You can build the bot's docker image via `build.ps1`. Then you can run the bot with `run.ps1`.
**Note:** Since the bot expects the environment variable `AFK4EVENTS_BOT_TOKEN`, be sure to provide this via the 
`config.env` file.

```
$ echo "AFK4EVENTS_BOT_TOKEN=<your>:<token>" > config.env
```

```
$ powershell build.ps1
$ powershell run.ps1 
```

```
```
