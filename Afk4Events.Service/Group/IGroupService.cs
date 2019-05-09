using System;

namespace Afk4Events.Service
{
    public interface IGroupService
    {
        void AddUserToGroup(Guid userId, Guid groupId);
    }
}