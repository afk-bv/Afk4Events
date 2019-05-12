param(
  [Parameter(Mandatory=$true)][string]$tag = "latest"
)

# If we have a private repository then push our image to that location.
if(Test-Path env:AFK4EVENTS_DOCKER_REPO_LOCATION)
{
  Write-Host "Deploying tag $($tag) to $($env:AFK4EVENTS_DOCKER_REPO_LOCATION)"
  docker tag "afk4events.telegrambot:$($tag)" "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.telegrambot:$($tag)"
  docker push "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.telegrambot:$($dev)"
}
else 
{ 
  Write-Host "Skipping Publish - variable AFK4EVENTS_DOCKER_REPO_LOCATION not defined."
}
