using System;
using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Models.Events
{
	public class EventDateDto
	{
		[Required] public DateTime Start { get; set; }
		[Required] public DateTime End { get; set; }
	}
}
