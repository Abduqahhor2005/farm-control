using FarmControl.Base.BaseInfo;
using FarmControl.Base.Extensions.PatternResultExtensions;
using MediatR;
namespace FarmControl.Features.Queries.Customer.CustomerViewModels;

public readonly record struct GetCustomerDetailViewModel(
    int Id,
    CustomerBaseInfo CustomerBaseInfo);
    
public record GetCustomerDetailViewModelRequest(int Id) : IRequest<Result<GetCustomerDetailViewModel>>;