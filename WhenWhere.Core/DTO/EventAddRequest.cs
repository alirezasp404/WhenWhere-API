using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.Domain.Entities;

namespace WhenWhere.Core.DTO
{
    public class EventAddRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]

        public string Description { get; set; }

        [Required]

        public DateTime? ExpiredAt { get; set; }

        [Required]

        public DateTime? CreatedAt { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Required]

        public string Location { get; set; }

        [Required]

        public Guid EventCreatorId { get; set; }

        public Event ToEvent(EventAddRequest request)
        {
            return new Event
            {
                Title = request.Title,
                Description = request.Description,
                ExpiredAt = request.ExpiredAt,
                CreatedAt = request.CreatedAt,
                Capacity = request.Capacity,
                Location = request.Location,
                EventCreatorId = request.EventCreatorId
            };   
        }
    }

}
