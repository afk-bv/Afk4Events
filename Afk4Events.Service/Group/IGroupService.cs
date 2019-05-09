using System;

namespace Afk4Events.Service.Group
{
    public interface IGroupService
    {
        void AddUserToGroup(Guid userId, Guid groupId);
    }
}