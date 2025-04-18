using Resto.Domain.Common;
using System;

namespace Resto.Domain.Models
{
    public class Ingredient : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Unit { get; set; }
        public int RecordThreshold { get; set; }
    }
}