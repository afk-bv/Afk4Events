using System;
using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Data.Entities
{
    public class UserGroup
    {
        [Key]
        public User User { get; set; }
        public Guid UserId { get; set; }
        [Key]
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public bool IsAdmin { get; set; }
    }
}