using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Customer.CustomerCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.CustomerCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Customer.CustomerCommandHandler;

public class UpdateCustomerHandler(ICustomerCommandRepository customerCommandRepository):IRequestHandler<UpdateCustomerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Customer?> existingCustomers = await customerCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Entities.Customer customer = existingCustomers.FirstOrDefault()!;
        if (customer is null) return BaseResult.Failure(Error.None());
        
        bool check = (await customerCommandRepository.FindAsync(x =>
            x.Email.ToLower().Contains(request.CustomerBaseInfo.Email.ToLower())
            || x.PhoneNumber==request.CustomerBaseInfo.PhoneNumber)).Any();
        if (check)
            return BaseResult.Failure(Error.AlreadyExist());

        int res = await customerCommandRepository.UpdateAsync(customer.ToUpdatedCustomer(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Customer not updated !!!"))
            : BaseResult.Success();
    }
}