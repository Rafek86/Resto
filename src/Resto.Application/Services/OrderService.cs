using Resto.Application.Common.Exceptions;
using Resto.Application.Common.Interfaces.Repositories;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.DTOs;
using Resto.Application.Features.Orders.Commands.Add;
using Resto.Application.Features.Orders.Commands.Delete;
using Resto.Application.Features.Orders.Commands.Update;
using Resto.Application.Features.Orders.Queries.GetOrder;
using Resto.Application.Features.Orders.Queries.GetOrderByCustomer;
using Resto.Domain.Enums;
using Resto.Domain.Models;
using System.Linq;

namespace Resto.Application.Services
{
    public class OrderService(IOrderRepository orderRepository, IOrderItemService orderItemService, IMenuRepository menuRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;
        private readonly IOrderItemService _orderItemService = orderItemService;
        private readonly IMenuRepository _menuRepository = menuRepository;

        public async Task<PlaceOrderResult> PlaceOrderAsync(PlaceOrderCommand command)
        {
            var orderItems = new List<OrderItem>();

            foreach (var item in command.Items)
            {
                var menuItem = await _menuRepository.GetMenuItemByIdAsync(item.MenuItemId);
                if (menuItem == null)
                    throw new NotFoundException("MenuItem", item.MenuItemId);

                var orderItem = OrderItem.Create(
                    "",
                    item.MenuItemId,
                    item.Quantity,
                    menuItem.Price
                );

                orderItems.Add(orderItem);
            }

            var order = Order.Create(command.CustomerId, command.TableNumber, 0, orderItems);

            foreach (var item in orderItems)
                item.OrderId = order.Id;

            await _orderRepository.AddAsync(order);

            return new PlaceOrderResult(order.Id, order.TotalPrice, order.OrderStatus);
        }


        public async Task<UpdateOrderResult> UpdateOrderStatusAsync(UpdateOrderCommand command)
        {
            if (await _orderRepository.GetByIdAsync(command.OrderId) is not { } order)
                throw new NotFoundException("Order", $"{command.OrderId}");

            order.UpdateStatus(command.OrderStatus);

            await _orderRepository.UpdateAsync(order);
            return new UpdateOrderResult(true);
        }

        public async Task<CancelOrderResult> CancelOrderAsync(CancelOrderCommand command)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId);
            if (order == null)
                throw new NotFoundException("Order", $"{command.OrderId}");

            order.Delete(); // sets IsDeleted = true and raises event
            await _orderRepository.UpdateAsync(order);
            return new CancelOrderResult(true);
        }


        public async Task<GetOrderByIdResult> GetOrderDetailsAsync(GetOrderByIdQuery query)
        {
            if (await _orderRepository.GetByIdAsync(query.OrderId) is not { } order)
                throw new NotFoundException("Order", $"{query.OrderId}");

            var orderItems = order.OrderItems.Select(item => new OrderItemDto(
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


    }
}
