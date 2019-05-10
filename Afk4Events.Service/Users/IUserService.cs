using System;
using Afk4Events.Data.Entities.Users;

namespace Afk4Events.Service.Users
{
	public interface IUserService
	{
		void Create(User user);
		User Get(Guid id);
	}
}
