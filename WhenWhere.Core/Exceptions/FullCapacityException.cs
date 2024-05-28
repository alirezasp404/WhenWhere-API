using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenWhere.Core.Exceptions
{
    public class FullCapacityException : ArgumentException
    {
        public FullCapacityException(string? message) : base(message) { }
    }
}
