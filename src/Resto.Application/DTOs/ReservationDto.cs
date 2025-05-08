using Resto.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
   public record ReservationDto(
       string Id,
       int TableNumber,
       int PartySize,
       DateTime ReservationDate,
       string TablesStatus,
       string CustomerId,
       string CustomerName
       );
}
