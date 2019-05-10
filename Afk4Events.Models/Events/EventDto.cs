using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Models.Events
{
	public class EventDto
	{
		[Required] [MaxLength(500)] public string Name { get; set; }
		[Required] [MaxLength(250)] public string ThemeName { get; set; }
		[Required] [MaxLength(1000)] public string Location { get; set; }
		public IList<EventDateDto> EventDates { get; set; }
		[Required] public Guid GroupId { get; set; }
	}
}
