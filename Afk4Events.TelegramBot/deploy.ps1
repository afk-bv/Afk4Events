# If we have a private repository then push our image to that location.
if(Test-Path env:AFK4EVENTS_DOCKER_REPO_LOCATION)
{
  docker tag afk4events.telegrambot:latest "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.telegrambot"
  docker push "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.telegrambot"
}
else 
{ 
  Write-Host "Skipping Publish - variable AFK4EVENTS_DOCKER_REPO_LOCATION not defined."
}
