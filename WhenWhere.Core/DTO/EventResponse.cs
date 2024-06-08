using Microsoft.AspNetCore.Http;
using WhenWhere.Core.Domain.Entities;

namespace WhenWhere.Core.DTO
{
    public record EventResponse(Guid? Id,
                                string? Title,
                                string? Description,
                                DateTime? ExpiredAt,
                                int? Capacity,
                                string? Location,
                                string? EventCreator);

    public static class EventExtension
    {
        public static EventResponse ToEventResponse(this Event eventModel)
        {
            return new EventResponse(
                eventModel?.Id,
                eventModel?.Title,
                eventModel?.Description,
                eventModel?.ExpiredAt,
                eventModel?.Capacity,
                eventModel?.Location,
                eventModel?.EventCreator?.UserName);
        }
    }
}
