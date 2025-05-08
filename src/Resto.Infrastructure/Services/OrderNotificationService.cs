
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

            var menuItemTasks = order.OrderItems.Select(item =>
                _menuRepository.GetMenuItemByIdAsync(item.MenuItemId));
            var menuItems = await Task.WhenAll(menuItemTasks);

            var templateData = new Dictionary<string, string>
            {
               { "{{OrderId}}", order.Id },
               { "{{TableNumber}}", order.TableNumber.ToString() },
               { "{{TotalPrice}}", order.TotalPrice.ToString("C") },
               { "{{OrderStatus}}", order.OrderStatus.ToString() },
               { "{{OrderDate}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm") }
           };

            var orderItemsHtml = new StringBuilder();
            for (int i = 0; i < order.OrderItems.Count(); i++)
            {
                var item = order.OrderItems[i];
                var menuItem = menuItems[i];
                var itemName = menuItem?.Name ?? $"Item #{item.MenuItemId}";
                var total = item.Quantity * item.UnitPrice;

                orderItemsHtml.AppendLine($@"
                <tr>
                    <td>{itemName}</td>
                    <td>{item.Quantity}</td>
                    <td>{item.UnitPrice:C}</td>
                    <td>{total:C}</td>
                </tr>");
            }

            templateData.Add("{{OrderItems}}", orderItemsHtml.ToString());

            string emailBody = EmailBuilder.GenerateEmailBody("OrderConfirmation", templateData);
            string subject = $"Order Confirmation - Order #{orderId}";

            await _emailSender.SendEmailAsync(customerEmail, subject, emailBody);
        }



        public async Task SendOrderStatusUpdateAsync(string orderId, string customerEmail)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return;

            var templateData = new Dictionary<string, string>
            {
                { "{{OrderId}}", order.Id },
                { "{{TableNumber}}", order.TableNumber.ToString() },
                { "{{TotalPrice}}", order.TotalPrice.ToString("C") },
                { "{{OrderStatus}}", order.OrderStatus.ToString() },
                { "{{UpdateDate}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm") }
            };

            string emailBody = EmailBuilder.GenerateEmailBody("OrderStatusUpdate", templateData);
            string subject = $"Order Status Update - Order #{orderId}";

            await _emailSender.SendEmailAsync(customerEmail, subject, emailBody);
        }

        public async Task SendOrderCancelledAsync(string orderId, string customerEmail)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return;

            var templateData = new Dictionary<string, string>
            {
                { "{{OrderId}}", order.Id },
                { "{{TableNumber}}", order.TableNumber.ToString() },
                { "{{CancellationDate}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm") }
            };
            string emailBody = EmailBuilder.GenerateEmailBody("OrderCancellation", templateData);
            string subject = $"Order Cancelled - Order #{orderId}";

            await _emailSender.SendEmailAsync(customerEmail, subject, emailBody);
        }
    }
}