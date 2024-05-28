
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenWhere.Core.DTO;

namespace WhenWhere.Core.ServiceContracts
{
    public interface IRegisterEventsService
    {
        /// <summary>
        /// Registers User in an event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Task RegisterEvent(Guid? eventId, string? userId);

    }
}
