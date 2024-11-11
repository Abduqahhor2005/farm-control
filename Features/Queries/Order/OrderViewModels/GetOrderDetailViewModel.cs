using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;
namespace FarmControl.Features.Queries.Order.OrderViewModels;

public readonly record struct GetOrderDetailViewModel(
    int Id,
    OrderBaseInfo OrderBaseInfo);
    
public record GetOrderDetailViewModelRequest(int Id) : IRequest<Result<GetOrderDetailViewModel>>;