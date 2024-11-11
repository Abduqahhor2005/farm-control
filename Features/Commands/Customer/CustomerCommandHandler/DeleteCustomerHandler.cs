using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Customer.CustomerCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.CustomerCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Customer.CustomerCommandHandler;

public class DeleteCustomerHandler(ICustomerCommandRepository customerCommandRepository)
    :IRequestHandler<DeleteCustomerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Customer?> existingCustomers = await customerCommandRepository.FindAsync(x =>
            x.Id == request.Id);
        Entities.Customer? existing = existingCustomers.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await customerCommandRepository.UpdateAsync(existing.ToDeletedCustomer());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Customer not deleted !!!"))
            : BaseResult.Success();
    }
}