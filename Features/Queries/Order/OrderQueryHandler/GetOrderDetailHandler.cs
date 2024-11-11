using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Queries.Order.OrderViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Order.OrderQueryHandler;

public class GetOrderDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetOrderDetailViewModelRequest, Result<GetOrderDetailViewModel>>
{
    public async Task<Result<GetOrderDetailViewModel>> Handle(GetOrderDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Entities.Order? result = await context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetOrderDetailViewModel>.Failure(Error.NotFound())
            : Result<GetOrderDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}