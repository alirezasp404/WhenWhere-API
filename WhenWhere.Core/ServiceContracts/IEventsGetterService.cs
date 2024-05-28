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
        public Task<IEnumerable<EventResponse>?> GetAllEvents(string? userId);

        /// <summary>
        /// Returns created events.
        /// </summary>
        /// <param name="userId">user Id.</param>
        /// <returns> All events those registered  by the user.</returns>
        public Task<IEnumerable<EventResponse>?> GetCreatedEvents(string? userId);

        /// <summary>
        /// Returns registered events.
        /// </summary>
        /// <param name="userId">user Id.</param>
        /// <returns> All events those created  by the user.</returns>
        public Task<IEnumerable<EventResponse>?> GetRegisteredEvents(string? userId);
    }
}
