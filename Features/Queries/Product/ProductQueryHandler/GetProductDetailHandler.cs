using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Queries.Product.ProductViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Product.ProductQueryHandler;

public class GetProductDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetProductDetailViewModelRequest, Result<GetProductDetailViewModel>>
{
    public async Task<Result<GetProductDetailViewModel>> Handle(GetProductDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Entities.Product? result = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetProductDetailViewModel>.Failure(Error.NotFound())
            : Result<GetProductDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}