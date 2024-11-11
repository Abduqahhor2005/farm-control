using FarmControl.Base.Data;
using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Customer.CustomerViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FarmControl.Features.Queries.Customer.CustomerQueryHandler;

public class GetCustomersHandler(AppQueryDbContext context) : IRequestHandler<GetCustomerViewModelRequest, Result<PagedResponse<IEnumerable<GetCustomerViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetCustomerViewModel>>>> Handle(GetCustomerViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Entities.Customer> customers = context.Customers;

        if (request.Filter!.Age != null)
            customers = customers.Where(x => x.Age==request.Filter.Age);
        if (request.Filter.FullName is not null)
            customers = customers.Where(x => x.FullName.ToLower()
                .Contains(request.Filter.FullName.ToLower()));
        if (request.Filter.Email is not null)
            customers = customers.Where(x => x.Email.ToLower()
                .Contains(request.Filter.Email.ToLower()));
        if (request.Filter.PhoneNumber is not null)
            customers = customers.Where(x => x.PhoneNumber.ToLower()
                .Contains(request.Filter.PhoneNumber.ToLower()));
        if (request.Filter.Address is not null)
            customers = customers.Where(x => x.Address.ToLower()
                .Contains(request.Filter.Address.ToLower()));

        int count = await customers.CountAsync(cancellationToken);

        IQueryable<GetCustomerViewModel> result = customers
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetCustomerViewModel>> response = PagedResponse<IEnumerable<GetCustomerViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetCustomerViewModel>>>.Success(response);
    }
}