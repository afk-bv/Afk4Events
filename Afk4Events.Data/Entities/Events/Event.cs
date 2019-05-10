using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Afk4Events.Data.Entities.Groups;
using Afk4Events.Data.Entities.Themes;
using Afk4Events.Data.Entities.Users;

namespace Afk4Events.Data.Entities.Events
{
	/// <summary>
	///   The Event class represents a single schedulable event. An event must have an owner
	///   and consists of one or more possible dates, of which one may be 'pinned'.
	/// </summary>
	public class Event
	{
		/// <summary>
		///   This Event its unique identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		///   This event its optional comment text.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		///   The group to which owns the event
		/// </summary>
		public Group Group { get; set; }

		public Guid GroupId { get; set; }

		/// <summary>
		///   The theme of the event
		/// </summary>
		public Theme Theme { get; set; }

		public string ThemeId { get; set; }

		/// <summary>
		///   The name of the event
		/// </summary>
		[MaxLength(500)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// </summary>
		[MaxLength(1000)]
		[Required]
		public string Location { get; set; }

		/// <summary>
		///   The that has been picked
		/// </summary>
		public EventDate PickedDate { get; set; }

		public Guid? PickedDateId { get; set; }

		/// <summary>
		///   An event has one or more possible event dates on which the event could take place.
		/// </summary>
		public IList<EventDate> EventDates { get; set; }

		/// <summary>
		///   An event always has an owner. The owner may perform administrative actions on an event
		///   such as selecting a 'final' event date, altering the description, or altering the list of event dates.
		/// </summary>
		public User CreatedBy { get; set; }

		public Guid CreatedById { get; set; }
	}
}
