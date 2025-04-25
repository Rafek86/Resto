using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
    public record CustomerDto(
        Guid Id,
        string Name,
        string Email
    );
}
