using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Domain.Enums
{
    public enum NotificationType
    {
        General = 0,
        Confirmation = 1,
        LowStockItems = 2,
        OrderPlaced = 3,
        ReservationCanceled = 4,
        OrderUpdate = 5,
        OrderCancelled = 6
    }
}
