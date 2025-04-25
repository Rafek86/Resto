using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
    public class IngredientDto
    {
        public string Name { get;}
        public int Unit { get; }
        public int RecordThreshold { get; }
        public bool IsAvailable { get; } 
    }
}
