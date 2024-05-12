using WhenWhere.Core.DTO;

namespace WhenWhere.Core.ServiceContracts
{/// <summary>
/// Represents business logic for manipulating Event entity.
/// </summary>
    public interface IEventsGetterService
    {
        /// <summary>
        /// Returns all events.
        /// </summary>
        /// <param name="userId">user Id.</param>
        /// <returns> All events except those created or registered to by the user.</returns>
        public IEnumerable<EventResponse>? GetAllEvents(Guid? userId);

        /// <summary>
        /// Returns created events.
        /// </summary>
        /// <param name="userId">user Id.</param>
        /// <returns> All events those registered  by the user.</returns>
        public IEnumerable<EventResponse>? GetCreatedEvents(Guid? userId);

        /// <summary>
        /// Returns registered events.
        /// </summary>
        /// <param name="userId">user Id.</param>
        /// <returns> All events those created  by the user.</returns>
        public IEnumerable<EventResponse>? GetRegisteredEvents(Guid? userId);

        /// <summary>
        /// Returns user profile.
        /// </summary>
        /// <param name="userId">user Id.</param>
        /// <returns> user profile information.</returns>
        public UserProfile? GetUserProfile(Guid? userId);
    }
}
