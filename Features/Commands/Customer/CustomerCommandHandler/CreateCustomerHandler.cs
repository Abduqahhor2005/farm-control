using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Customer.CustomerCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.CustomerCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Customer.CustomerCommandHandler;

public class CreateCustomerHandler(ICustomerCommandRepository customerCommandRepository):IRequestHandler<CreateCustomerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        bool check = (await customerCommandRepository.FindAsync(x =>
            x.Email.ToLower().Contains(request.CustomerBaseInfo.Email.ToLower()))).Any();
        if (check)
            return BaseResult.Failure(Error.AlreadyExist());
        int res = await customerCommandRepository.AddAsync(request.ToCustomer());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Customer not saved !!!"))
            : BaseResult.Success();
    }
}