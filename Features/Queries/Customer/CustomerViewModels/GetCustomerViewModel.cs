using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Customer.CustomerViewModels;

public readonly record struct GetCustomerViewModel(
    int Id,
    CustomerBaseInfo CustomerBaseInfo);

public record GetCustomerViewModelRequest(CustomerFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetCustomerViewModel>>>>;