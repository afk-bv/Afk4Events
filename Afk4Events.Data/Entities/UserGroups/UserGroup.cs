using System;
using System.ComponentModel.DataAnnotations;
using Afk4Events.Data.Entities.Groups;
using Afk4Events.Data.Entities.Users;

namespace Afk4Events.Data.Entities.UserGroups
{
	/// <summary>
	///   Mapping between User and Group
	///   Used as Many-To-Many
	/// </summary>
	public class UserGroup
	{
		/// <summary>
		///   The User which is a member of the Group
		/// </summary>
		[Key]
		public User User { get; set; }

		public Guid UserId { get; set; }

		/// <summary>
		///   The Group to which this User is a member of.
		/// </summary>
		[Key]
		public Group Group { get; set; }

		public Guid GroupId { get; set; }

		/// <summary>
		///   Specifies whether the User is an administrator of the Group.
		/// </summary>
		public bool IsAdmin { get; set; }
	}
}
