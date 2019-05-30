using Microsoft.AspNetCore.Components;

namespace Afk4Events.WebClient.ViewModels.Components.EventTitle
{
  public class EventTitleViewModel : ComponentBase
  {
	[Parameter] protected string Title { get; set; }
	[Parameter] protected string ImageURL { get; set; }

	protected string PickedDate { get; set; } = "07-07-1991";
	protected string TimeRemaining { get; set; } = "16 hours";
  }
}
