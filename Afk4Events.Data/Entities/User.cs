using System;
using System.Collections.Generic;
using System.Text;

namespace Afk4Events.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// maps to 'sub' claim of id tokens issued by Google
        /// https://developers.google.com/identity/protocols/OpenIDConnect
        /// </summary>
        public string GoogleId { get; set; }
    }
}
