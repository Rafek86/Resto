using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
    public record AuthResponse(
        string Id,
        string? Email,
        string Token,
        int ExpiresIn
        );
}
