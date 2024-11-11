using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Product.ProductViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Product.ProductQueryHandler;

public class GetProductsHandler(AppQueryDbContext context) : IRequestHandler<GetProductViewModelRequest, Result<PagedResponse<IEnumerable<GetProductViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetProductViewModel>>>> Handle(GetProductViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Product> products = context.Products;

        if (request.Filter!.Name is not null)
            products = products.Where(x => x.Name.ToLower()
                .Contains(request.Filter.Name.ToLower()));
        if (request.Filter!.Price != null)
            products = products.Where(x => x.Price==request.Filter.Price);
        if (request.Filter!.QuantityAvailable != null)
            products = products.Where(x => x.QuantityAvailable==request.Filter.QuantityAvailable);
        if (request.Filter!.FarmerId != null)
            products = products.Where(x => x.FarmerId==request.Filter.FarmerId);

        int count = await products.CountAsync(cancellationToken);

        IQueryable<GetProductViewModel> result = products
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetProductViewModel>> response = PagedResponse<IEnumerable<GetProductViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetProductViewModel>>>.Success(response);
    }
}