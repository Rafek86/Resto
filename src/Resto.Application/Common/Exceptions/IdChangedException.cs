using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Exceptions
{
    public class IdChangedException : Exception
    {
        public IdChangedException(string key ,string Id) : base($"{key} {Id} Can't be Change ") { }
    }
}
