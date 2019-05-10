using System;

namespace Afk4Events.Service.Groups
{
	public interface IGroupService
	{
		void AddUserToGroup(Guid userId, Guid groupId);
	}
}
