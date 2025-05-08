using Resto.Application.Features.Orders.Commands.Add;
using Resto.Application.Features.Orders.Commands.Delete;
using Resto.Application.Features.Orders.Commands.Update;
using Resto.Application.Features.Orders.Queries.GetOrder;
using Resto.Application.Features.Orders.Queries.GetOrderByCustomer;
using Resto.Application.Features.Orders.Queries.GetPendingOrders;

namespace Resto.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IOrderNotificationService _notificationService;
        private readonly ICustomerRepository _customerRepository;
        public OrderService(
            IOrderRepository orderRepository,
            IMenuRepository menuRepository,
            ICustomerRepository customerRepository,
            IOrderNotificationService notificationService)
        {
            _orderRepository = orderRepository;
            _menuRepository = menuRepository;
            _notificationService = notificationService;
            _customerRepository = customerRepository;
        }

        public async Task<PlaceOrderResult> PlaceOrderAsync(PlaceOrderCommand command)
        {
            if (await _customerRepository.GetByIdAsync(command.CustomerId) is not { } customer)
                throw new NotFoundException("Customer", command.CustomerId);    

            var orderItems = new List<OrderItem>();
            decimal totalPrice = 0;

            foreach (var item in command.Items)
            {
                var menuItem = await _menuRepository.GetMenuItemByIdAsync(item.MenuItemId);
                if (menuItem == null)
                    throw new NotFoundException("MenuItem", item.MenuItemId);

                decimal itemTotalPrice = menuItem.Price * item.Quantity;
                totalPrice += itemTotalPrice;

                var orderItem = OrderItem.Create(
                    "",  
                    item.MenuItemId,
                    item.Quantity,
                    menuItem.Price
                );

                orderItems.Add(orderItem);
            }

            var order = Order.Create(command.CustomerId, command.TableNumber, totalPrice, orderItems);

            foreach (var item in orderItems)
                item.OrderId = order.Id;

             await _orderRepository.AddAsync(order);

            return new PlaceOrderResult(order.Id, order.TotalPrice, order.OrderStatus.ToString());
        }

        public async Task<UpdateOrderResult> UpdateOrderStatusAsync(UpdateOrderCommand command)
        {
            if (await _orderRepository.GetByIdAsync(command.OrderId) is not { } order)
                throw new NotFoundException("Order", $"{command.OrderId}");

            order.UpdateStatus(command.OrderStatus);

            await _orderRepository.UpdateAsync(order);

            
             await _notificationService.SendOrderStatusUpdateAsync(order.Id, order.Customer.Email!);

            return new UpdateOrderResult(true);
        }

        public async Task<CancelOrderResult> CancelOrderAsync(CancelOrderCommand command)
        {

            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (order == null)
                throw new NotFoundException("Order", $"{command.OrderId}");

            order.Delete(); 
            await _orderRepository.UpdateAsync(order);

            return new CancelOrderResult(true);
        }

        public async Task<GetOrderByIdResult> GetOrderDetailsAsync(GetOrderByIdQuery query)
        {
            if (await _orderRepository.GetByIdAsync(query.OrderId) is not { } order)
                throw new NotFoundException("Order", $"{query.OrderId}");

            var orderItems = order.OrderItems.Select(item => new  OrderItemDto(
                item.MenuItemId,
                item.Quantity,
                item.UnitPrice
            )).ToList();

            return new GetOrderByIdResult(new OrderDto(
                order.Id,
                order.CustomerId,
                order.TableNumber,
                order.OrderStatus,
                order.TotalPrice,
                orderItems
            ));
        }

        public async Task<GetOrderByCustomerResult> GetOrdersForCustomerAsync(GetOrderByCustomerQuery query)
        {
            var orders = await _orderRepository.GetOrdersByCustomerIdAsync(query.CustomerId);

            var result = orders.Select(order => new OrderDto(
              order.Id,
              order.CustomerId,
              order.TableNumber,
              order.OrderStatus,
              order.TotalPrice,
              order.OrderItems.Select(item => new OrderItemDto(
                  item.MenuItemId,
                  item.Quantity,
                  item.UnitPrice
              )).ToList()
          )).ToList();

            return new GetOrderByCustomerResult(result);
        }

        public async Task<GetPendingOrdersResult> GetPendingOrdersAsync(GetPendingOrdersQuery query)
        {
            var orders = await _orderRepository.GetPendingOrdersAsync();

            var result = orders.Select(order => new OrderDto(
                order.Id,
                order.CustomerId,
                order.TableNumber,
                order.OrderStatus,
                order.TotalPrice,
                order.OrderItems.Select(item => new OrderItemDto(
                    item.MenuItemId,
                    item.Quantity,
                    item.UnitPrice
                )).ToList()
            )).ToList();

            return new GetPendingOrdersResult(result);
        }
    }
}