using FarmControl.Features.Commands.Order.OrderCommandRequest;
using FarmControl.Features.Entities;
using FarmControl.Features.Queries.Order.OrderViewModels;

namespace FarmControl.Base.Extensions.Mappers;

public static class OrderMappingExtension
{
    public static GetOrderViewModel ToReadInfo(this Order order)
    {
        return new()
        {
            Id = order.Id,
            OrderBaseInfo = new()
            {
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                ProductId = order.ProductId,
                CustomerId = order.CustomerId
            }
        };
    }
    
    public static GetOrderDetailViewModel ToReadDetailInfo(this Order order)
    {
        return new()
        {
            Id = order.Id,
            OrderBaseInfo = new()
            {
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                ProductId = order.ProductId,
                CustomerId = order.CustomerId
            }
        };
    }

    public static Order ToOrder(this CreateOrderRequest request)
    {
        return new()
        {
            Quantity = request.OrderBaseInfo.Quantity,
            OrderDate = request.OrderBaseInfo.OrderDate,
            ProductId = request.OrderBaseInfo.ProductId,
            CustomerId = request.OrderBaseInfo.CustomerId
        };
    }

    public static Order ToUpdatedOrder(this Order order, UpdateOrderRequest request)
    {
        order.Version++;
        order.UpdatedAt = DateTime.UtcNow;
        order.Quantity = request.OrderBaseInfo.Quantity;
        order.OrderDate = request.OrderBaseInfo.OrderDate;
        order.ProductId = request.OrderBaseInfo.ProductId;
        order.CustomerId = request.OrderBaseInfo.CustomerId;
        return order;
    }

    public static Order ToDeletedOrder(this Order order)
    {
        order.IsDeleted = true;
        order.DeletedAt = DateTime.UtcNow;
        order.UpdatedAt = DateTime.UtcNow;
        order.Version++;
        return order;
    }
}