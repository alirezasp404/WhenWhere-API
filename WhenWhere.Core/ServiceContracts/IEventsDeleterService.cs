using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenWhere.Core.ServiceContracts
{
    public interface IEventsDeleterService
    {
        Task<bool> DeleteEvent(Guid? eventId,string? userId);
    }
}
