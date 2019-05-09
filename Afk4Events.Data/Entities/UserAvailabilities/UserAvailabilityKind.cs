namespace Afk4Events.Data.Entities.UserAvailabilities
{
    /// <summary>
    /// Possible Availability States for users.
    /// </summary>
    public enum UserAvailabilityKind
    {
        /// <summary>
        /// User is available.
        /// </summary>
        Available,

        /// <summary>
        /// User might be available, uncertain.
        /// </summary>
        MaybeAvailable,

        /// <summary>
        /// User is not available on this date and time.
        /// </summary>
        Unavailable
    }
}