using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.DTOs
{
   public record ReservationDto(
       string ReservationId,
       int TableNumber,
       int PartySize,
       DateTime ReservationDate,
       string CustomerId,
       string CustomerName
       );
}
