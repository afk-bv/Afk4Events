using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Afk4Events.Data.Entities.Events;
using Afk4Events.Data.Entities.UserGroups;

namespace Afk4Events.Data.Entities.Groups
{
	public class Group
	{
		/// <summary>
		///   Unique group identifier.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		///   This Group its name.
		/// </summary>
		[MaxLength(250)]
		public string Name { get; set; }

		/// <summary>
		///   The users which are members of this Group.
		/// </summary>
		public IList<UserGroup> Users { get; set; }

		/// <summary>
		///   The events that belong to this Group.
		/// </summary>
		public IList<Event> Events { get; set; }
	}
}
