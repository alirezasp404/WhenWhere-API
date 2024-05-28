﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
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

        [BindNever]
        public string? EventCreatorId { get; set; }

        public Event ToEvent()
        {

            return new Event
            {
                Title = this.Title,
                Description = this.Description,
                ExpiredAt = this.ExpiredAt,
                CreatedAt = this.CreatedAt,
                Capacity = this.Capacity,
                Location = this.Location,
                EventCreatorId = this.EventCreatorId,
            };
        }
    }
}
