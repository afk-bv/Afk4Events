using Afk4Events.Data.Entities;
using System;

namespace Afk4Events.Service
{
    public interface IUserService
    {
        void Create(User user);
        User Get(Guid id);
    }
}