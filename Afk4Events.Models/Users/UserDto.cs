namespace Afk4Events.Models.Users
{
    public class UserDto
    {
        /// <summary>
        /// Fullname of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Absolute URI to image asset
        /// </summary>
        public string ProfilePictureUrl { get; set; }

        public UserDto(string name, string email, string profilePictureUrl)
        {
            Name = name;
            Email = email;
            ProfilePictureUrl = profilePictureUrl;
        }

        /// <summary>
        /// Used by deserializers
        /// </summary>
        public UserDto()
        {
            
        }
    }
}
