using System.Linq.Expressions;
using System;
using WhenWhere.Core.Domain.Entities;
using WhenWhere.Core.DTO;

namespace WhenWhere.Core.Domain.RepositoryContracts
{
    public interface IEventsRepository
    {
        /// <summary>
        /// Create an Event object in data store.
        /// </summary>
        /// <param name="eventModel">Event object to create.</param>
        Task CreateEvent(Event eventModel);

        /// <summary>
        /// Returns all Events in the data store.
        /// </summary>
        /// <param name="userId">UserId.</param>
        /// <returns>List of Events objects from table. </returns>
        IQueryable<Event>? GetAllEvents(string? userId);

        /// <summary>
        /// Returns all created Events by given userId.
        /// </summary>
        /// <param name="userId">UserId.</param>
        /// <returns>all created Events by given userId. </returns>
        IQueryable<Event>? GetCreatedEvents(string? userId);

        /// <summary>
        /// Returns all registered Events by given userId.
        /// </summary>
        /// <param name="userId">UserId.</param>
        /// <returns>all created registered by given userId. </returns>
        IQueryable<Event?>? GetRegisteredEvents(string? userId);

        /// <summary>
        /// register an user in selected event.
        /// </summary>
        /// <param name="userId">user Id to register.</param>
        /// <param name="eventId">event Id to register.</param>
        Task RegisterForEvent(RegisteredEvent registeredEvent);
    }
}
