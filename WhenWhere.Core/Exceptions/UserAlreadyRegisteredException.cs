using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenWhere.Core.Exceptions
{
    public class UserAlreadyRegisteredException:ArgumentException
    {
        public UserAlreadyRegisteredException(string? message):base(message) { }
    }
}
