using Microsoft.AspNetCore.Identity.UI.Services;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using Resto.Domain.Email;
using Resto.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resto.Infrastructure.Services
{


    public class OrderNotificationService(
            IEmailSender emailSender,
            IOrderRepository orderRepository,
            IMenuRepository menuRepository,
            INotificationRepository notificationRepository
        ) : IOrderNotificationService
    {
        private readonly IEmailSender     _emailSender = emailSender;
        private readonly IOrderRepository  _orderRepository = orderRepository;
        private readonly IMenuRepository   _menuRepository = menuRepository;
        private readonly INotificationRepository _notificationRepository = notificationRepository;

        public async Task SendOrderConfirmationAsync(string orderId, string customerEmail)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return;

            var menuItemTasks = order.OrderItems.Select(async item =>
                await _menuRepository.GetMenuItemByIdAsync(item.MenuItemId));

            var menuItems = await Task.WhenAll(menuItemTasks);

            // Prepare template data
            var templateData = new Dictionary<string, string>
            {
                { "{{OrderId}}", order.Id },
                { "{{TableNumber}}", order.TableNumber.ToString() },
                { "{{TotalPrice}}", order.TotalPrice.ToString("C") },
                { "{{OrderStatus}}", order.OrderStatus.ToString() },
                { "{{OrderDate}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm") }
            };

            // Generate order items HTML
            var orderItemsHtml = new List<string>();
            for (int i = 0; i < order.OrderItems.Count(); i++)
            {
                var item = order.OrderItems[i];
                var menuItem = menuItems[i];
                var itemName = menuItem?.Name ?? $"Item #{item.MenuItemId}";

                orderItemsHtml.Add($"<tr><td>{itemName}</td><td>{item.Quantity}</td><td>{item.UnitPrice:C}</td><td>{(item.Quantity * item.UnitPrice):C}</td></tr>");
            }

            templateData.Add("OrderItems", string.Join("", orderItemsHtml));

            // Generate email body from template
            string emailBody = EmailBuilder.GenerateEmailBody("OrderConfirmation", templateData);
            string subject = $"Order Confirmation - Order #{orderId}";

            await _emailSender.SendEmailAsync(customerEmail, subject, emailBody);
        }

        public async Task SendOrderStatusUpdateAsync(string orderId, string customerEmail)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return;

            // Prepare template data
            var templateData = new Dictionary<string, string>
            {
                { "{{OrderId}}", order.Id },
                { "{{TableNumber}}", order.TableNumber.ToString() },
                { "{{TotalPrice}}", order.TotalPrice.ToString("C") },
                { "{{OrderStatus}}", order.OrderStatus.ToString() },
                { "{{UpdateDate}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm") }
            };

            // Generate email body from template
            string emailBody = EmailBuilder.GenerateEmailBody("OrderStatusUpdate", templateData);
            string subject = $"Order Status Update - Order #{orderId}";

            await _emailSender.SendEmailAsync(customerEmail, subject, emailBody);
        }

        public async Task SendOrderCancelledAsync(string orderId, string customerEmail)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return;

            // Prepare template data
            var templateData = new Dictionary<string, string>
            {
                { "{{OrderId}}", order.Id },
                { "{{TableNumber}}", order.TableNumber.ToString() },
                { "{{CancellationDate}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm") }
            };

            // Generate email body from template
            string emailBody = EmailBuilder.GenerateEmailBody("OrderCancellation", templateData);
            string subject = $"Order Cancelled - Order #{orderId}";

            await _emailSender.SendEmailAsync(customerEmail, subject, emailBody);
        }
    }
}