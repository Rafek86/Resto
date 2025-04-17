using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Domain.Common.Models
{
   public class AuditableEntity :BaseEntity<Guid>
    {
        public DateTimeOffset Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
