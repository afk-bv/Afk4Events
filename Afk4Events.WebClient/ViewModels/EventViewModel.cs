using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Afk4Events.Models.Events;
using Microsoft.AspNetCore.Components;

namespace Afk4Events.WebClient.ViewModels
{
  /// <summary>
  /// ViewModel for the Event/{id} page.
  /// </summary>
  public class EventViewModel : ComponentBase
  {
    /// <summary>
    /// Selected EventId.
    /// The Event Id gets passed as a URL parameter.
    /// </summary>
    [Parameter] public string EventId { get; set; }

    /// <summary>
    /// Currently selected event EventDto.
    /// </summary>
    public EventDto SelectedEvent;

    List<EventDto> Events = new List<EventDto>()
    {
      new EventDto() {
        Name = "Lord Of The Weeb III",
        ThemeName = "dank",
        Location = "My Location",
        GroupId = new Guid(),
        Description = "Lets go watch Lord of the Rings again.",
        ImageURL = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/71df2eb9-aa6d-4bb1-a46b-c4f68124289c/dbgatwe-f9f4af87-7ea7-4190-92e6-2404d9dafd13.png/v1/fill/w_900,h_505,q_80,strp/hatsune_miku_synthwave_vocaloid_retrowave_by_marusama97_dbgatwe-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NTA1IiwicGF0aCI6IlwvZlwvNzFkZjJlYjktYWE2ZC00YmIxLWE0NmItYzRmNjgxMjQyODljXC9kYmdhdHdlLWY5ZjRhZjg3LTdlYTctNDE5MC05MmU2LTI0MDRkOWRhZmQxMy5wbmciLCJ3aWR0aCI6Ijw9OTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.XlqZ3HUTogaS3ygOUF6NKiXdLuaNcSWDvoebTlpOulw"
      },
      new EventDto() {
        Name = "BBQ TestEvent",
        ThemeName = "dank",
        Location = "Location II",
        GroupId = new Guid(),
        Description = "BBQ @ Nick's place",
        ImageURL = "https://vignette.wikia.nocookie.net/universe-of-smash-bros-lawl/images/7/70/Inferno_Cop.jpg/revision/latest?cb=20160502030016"
      },
      new EventDto() {
        Name = "Hello World",
        ThemeName = "dank",
        Location = "Location III",
        GroupId = new Guid(),
        Description = "Goodbye world",
        ImageURL = "https://i.ytimg.com/vi/CUapPhdM7nc/maxresdefault.jpg"
      },
    };

    protected override void OnInit()
    {
      switch (EventId)
      {
        case "1":
          SelectedEvent = Events[0];
          break;
        case "2":
          SelectedEvent = Events[1];
          break;
        case "3":
          SelectedEvent = Events[2];
          break;
      }
    }

    protected override void OnParametersSet()
    {
      OnInit();
    }
  }
}
