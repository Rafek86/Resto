using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
  public record MenuDto(
        string Name,
        string Description,
        string Category,
        decimal Price,
        bool IsAvailable
      );
}
