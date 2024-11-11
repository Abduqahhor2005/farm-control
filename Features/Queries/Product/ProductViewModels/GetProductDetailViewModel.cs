using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;
namespace FarmControl.Features.Queries.Product.ProductViewModels;

public readonly record struct GetProductDetailViewModel(
    int Id,
    ProductBaseInfo ProductBaseInfo);
    
public record GetProductDetailViewModelRequest(int Id) : IRequest<Result<GetProductDetailViewModel>>;