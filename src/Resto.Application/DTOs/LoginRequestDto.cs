﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
    public record LoginRequestDto(
        string email,
        string password
        );
}
