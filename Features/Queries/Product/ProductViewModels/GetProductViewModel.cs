using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Product.ProductViewModels;

public readonly record struct GetProductViewModel(
    int Id,
    ProductBaseInfo ProductBaseInfo);

public record GetProductViewModelRequest(ProductFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetProductViewModel>>>>;