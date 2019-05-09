using System;

namespace Afk4Events.Service.User
{
    public interface IUserService
    {
        void Create(Data.Entities.Users.User user);
        Data.Entities.Users.User Get(Guid id);
    }
}