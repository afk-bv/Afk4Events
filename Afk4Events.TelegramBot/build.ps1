param(
  [Parameter(Mandatory=$true)][string]$tag
)

Set-Location -Path Afk4Events.TelegramBot
docker build -t "afk4events.telegrambot:$($tag)" .
