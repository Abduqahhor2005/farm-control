using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Queries.Customer.CustomerViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Customer.CustomerQueryHandler;

public class GetCustomerDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetCustomerDetailViewModelRequest, Result<GetCustomerDetailViewModel>>
{
    public async Task<Result<GetCustomerDetailViewModel>> Handle(GetCustomerDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Entities.Customer? result = await context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetCustomerDetailViewModel>.Failure(Error.NotFound())
            : Result<GetCustomerDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}