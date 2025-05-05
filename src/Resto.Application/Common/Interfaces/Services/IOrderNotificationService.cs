using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Services
{
    public interface IOrderNotificationService
    {
        Task SendOrderConfirmationAsync(string orderId, string customerEmail);
        Task SendOrderStatusUpdateAsync(string orderId, string customerEmail);
        Task SendOrderCancelledAsync(string orderId, string customerEmail);
    }
}
