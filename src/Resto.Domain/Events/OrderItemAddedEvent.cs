using Resto.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Domain.Events
{
    public record OrderItemAddedEvent(
        //string OrderId,
        //OrderItemDto OrderItemDto
        ) : IBaseEvent;
    
    //public record OrderItemDto(
    //    string Id,
    //    string OrderId,
    //    string MenuItemId,
    //    int Quantity
    //);
}
