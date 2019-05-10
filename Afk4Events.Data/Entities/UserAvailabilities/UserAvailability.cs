using System;
using Afk4Events.Data.Entities.Events;
using Afk4Events.Data.Entities.Users;

namespace Afk4Events.Data.Entities.UserAvailabilities
{
	/// <summary>
	///   A UserAvailability represents a response by an invited User to some Event.
	///   An availability highlights whether or not a user is available on that date and time.
	/// </summary>
	public class UserAvailability
	{
		/// <summary>
		///   User that subscribed to this event.
		/// </summary>
		public Guid UserId { get; set; }

		public User User { get; set; }

		/// <summary>
		///   Event to which this date belongs
		/// </summary>
		public Guid EventDateId { get; set; }

		public EventDate EventDate { get; set; }

		/// <summary>
		///   Optional comment.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		///   The availability state of the User at this EventDate
		/// </summary>
		public UserAvailabilityKind AvailabilityKind { get; set; }
	}
}
