using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.DTO;

namespace WhenWhere.Core.ServiceContracts
{
    public interface IEventsAdderService
    {
        Task<EventResponse> AddEvent(EventAddRequest request);
    }
}
