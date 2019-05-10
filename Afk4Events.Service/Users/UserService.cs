using System;
using Afk4Events.Data;

namespace Afk4Events.Service.Users
{
    public class UserService : IUserService
    {
        private readonly Afk4EventsContext _db;

        public UserService(Afk4EventsContext db)
        {
            _db = db;
        }

        public Data.Entities.Users.User Get(Guid id)
        {
            return _db.Users.Find(id);
        }

        public void Create(Data.Entities.Users.User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}
