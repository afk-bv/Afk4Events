using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Afk4Events.Data.Entities.UserGroups;

namespace Afk4Events.Data.Entities.Users
{
	/// <summary>
	///   The user class represents a registered user in the application. A user may subscribe to
	/// </summary>
	public class User
	{
		/// <summary>
		///   Empty constructor for EF
		/// </summary>
		public User()
		{
		}

		public User(string googleId)
		{
			GoogleId = googleId;
		}

		/// <summary>
		///   Unique Id for this user.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		///   This users' username
		/// </summary>
		[MaxLength(250)]
		[Required]
		public string Name { get; set; }

		/// <summary>
		///   This users' email address.
		/// </summary>
		[MaxLength(250)]
		[Required]
		public string Email { get; set; }

		/// <summary>
		///   Possible URL for this users profile picture.
		/// </summary>
		public string ProfilePictureUrl { get; set; }

		/// <summary>
		///   maps to 'sub' claim of id tokens issued by Google
		///   https://developers.google.com/identity/protocols/OpenIDConnect
		/// </summary>
		[MaxLength(250)]
		[Required]
		public string GoogleId { get; set; }

		/// <summary>
		///   List of the groups user is member of
		/// </summary>
		public IList<UserGroup> Groups { get; set; }
	}
}
