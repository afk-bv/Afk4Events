using System;
using Afk4Events.Data;
using Afk4Events.Data.Entities.Users;

namespace Afk4Events.Service.Users
{
	public class UserService : IUserService
	{
		private readonly Afk4EventsContext _db;

		public UserService(Afk4EventsContext db)
		{
			_db = db;
		}

		public User Get(Guid id)
		{
			return _db.Users.Find(id);
		}

		public void Create(User user)
		{
			_db.Users.Add(user);
			_db.SaveChanges();
		}
	}
}
