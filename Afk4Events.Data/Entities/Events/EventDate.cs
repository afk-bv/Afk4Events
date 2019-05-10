using System;
using System.Collections.Generic;
using Afk4Events.Data.Entities.UserAvailabilities;

namespace Afk4Events.Data.Entities.Events
{
	/// <summary>
	///   An event may have one or more Event Dates. An event date represents a single continuous time slot.
	///   Users can subscribe to an event date by providing an availability and optional comment.
	/// </summary>
	public class EventDate
	{
		/// <summary>
		///   This EventDate its unique identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		///   The beginning Date and Time of this event.
		/// </summary>
		public DateTime Start { get; set; }

		/// <summary>
		///   The ending Date and Time of this event.
		/// </summary>
		public DateTime End { get; set; }

		/// <summary>
		///   The event to which this date belongs
		/// </summary>
		public Event Event { get; set; }

		public Guid EventId { get; set; }
		
		/// <summary>
		///   The current availabilities for this event date.
		///   That is, a list of users and their availabilities.
		/// </summary>
		public IList<UserAvailability> UserAvailabilities { get; set; }
	}
}
