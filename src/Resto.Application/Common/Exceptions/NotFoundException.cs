﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Exceptions
{
   public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) not found.")
        {
        }
    }
}
