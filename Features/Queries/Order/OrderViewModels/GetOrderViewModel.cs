using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Order.OrderViewModels;

public readonly record struct GetOrderViewModel(
    int Id,
    OrderBaseInfo OrderBaseInfo);

public record GetOrderViewModelRequest(OrderFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetOrderViewModel>>>>;