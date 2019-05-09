using System;
using System.Linq;
using Afk4Events.Data;
using Afk4Events.Data.Entities.UserGroups;

namespace Afk4Events.Service.Group
{
    public class GroupService: IGroupService
    {
        private  readonly Afk4EventsContext _db;

        public GroupService(Afk4EventsContext db)
        {
            _db = db;
        }

        public void AddUserToGroup(Guid userId, Guid groupId)
        {
            if (userId == null)
            {
                throw new ArgumentException("UserId is required", nameof(userId));
            }

            if (groupId == null)
            {
                throw new ArgumentException("GroupId is required", nameof(groupId));
            }

            if (_db.UserGroups.Any(x => x.UserId == userId && x.GroupId == groupId))
            {
                throw new InvalidOperationException("User is already member of group");
            }

            _db.UserGroups.Add(new UserGroup()
            {
                GroupId = groupId,
                UserId = userId
            });
            _db.SaveChanges();
        }

    }
}
