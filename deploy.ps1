param(
  [Parameter(Mandatory=$true)][string] $project,
  [Parameter(Mandatory=$true)][string] $tag
)

if(Test-Path env:AFK4EVENTS_DOCKER_REPO_LOCATION)
{
  Write-Host "Deploying { project=$($project), tag=$($tag) } to $($env:AFK4EVENTS_DOCKER_REPO_LOCATION)"
  if($project.ToLower() -eq "api")
  {
    docker tag "afk4events.api:$($tag)" "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.api:$($tag)"
    docker push "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.api:$($tag)"
  }
  elseif($project.ToLower() -eq "telegrambot")
  {
    docker tag "afk4events.telegrambot:$($tag)" "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.telegrambot:$($tag)"
    docker push "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.telegrambot:$($tag)"
  }
  elseif($project.ToLower() -eq "webclient")
  {
    docker tag "afk4events.webclient:$($tag)" "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.webclient:$($tag)"
    docker push "$($env:AFK4EVENTS_DOCKER_REPO_LOCATION)/afk4events.webclient:$($tag)"
  }
  else
  {
    Write-Host "Unknown project."
    return 1;
  }
}
else
{
  Write-Host "Skipping Publish - variable AFK4EVENTS_DOCKER_REPO_LOCATION not defined."
}
