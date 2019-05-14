param(
  [Parameter(Mandatory=$true)][string] $project,
  [Parameter(Mandatory=$true)][string] $tag
)

if($project.ToLower() -eq "api") 
{
  docker build -t "afk4events.api:$($tag)" -f ./Afk4Events.Api/Dockerfile .
}
elseif($project.ToLower() -eq "telegrambot") 
{
  docker build -t "afk4events.telegrambot:$($tag)" -f ./Afk4Events.TelegramBot/Dockerfile .
}
elseif($project.ToLower() -eq "webclient") 
{
  docker build -t "afk4events.webclient:$($tag)" -f ./Afk4Events.WebClient/Dockerfile .
}
else 
{
  Write-Host "Unknown project."
  return 1;
}
