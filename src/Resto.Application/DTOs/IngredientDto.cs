using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
    public record IngredientDto(
     string Name,
     int Unit ,
     int RecordThreshold ,
     bool IsAvailable 
);
}
