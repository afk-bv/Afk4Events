dotnet ef database drop -f --startup-project Afk4Events.Data --project Afk4Events.Data 
dotnet ef migrations remove -f --startup-project Afk4Events.Data --project Afk4Events.Data 
dotnet ef migrations add initial  --startup-project Afk4Events.Data --project Afk4Events.Data 
dotnet ef database update  --startup-project Afk4Events.Data --project Afk4Events.Data 