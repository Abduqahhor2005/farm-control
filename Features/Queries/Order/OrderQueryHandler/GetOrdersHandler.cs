using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Order.OrderViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Order.OrderQueryHandler;

public class GetOrdersHandler(AppQueryDbContext context) : IRequestHandler<GetOrderViewModelRequest, Result<PagedResponse<IEnumerable<GetOrderViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetOrderViewModel>>>> Handle(GetOrderViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Order> orders = context.Orders;

        if (request.Filter!.Quantity != null)
            orders = orders.Where(x => x.Quantity==request.Filter.Quantity);
        if (request.Filter!.OrderDate != null)
            orders = orders.Where(x => x.OrderDate==request.Filter.OrderDate);
        if (request.Filter!.ProductId != null)
            orders = orders.Where(x => x.ProductId==request.Filter.ProductId);
        if (request.Filter!.CustomerId != null)
            orders = orders.Where(x => x.CustomerId==request.Filter.CustomerId);

        int count = await orders.CountAsync(cancellationToken);

        IQueryable<GetOrderViewModel> result = orders
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetOrderViewModel>> response = PagedResponse<IEnumerable<GetOrderViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetOrderViewModel>>>.Success(response);
    }
}