using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Order.OrderCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.OrderCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Order.OrderCommandHandler;

public class DeleteOrderHandler(IOrderCommandRepository orderCommandRepository)
    :IRequestHandler<DeleteOrderRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Order?> existingOrders = await orderCommandRepository.FindAsync(x =>
            x.Id == request.Id);
        Entities.Order? existing = existingOrders.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await orderCommandRepository.UpdateAsync(existing.ToDeletedOrder());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Order not deleted !!!"))
            : BaseResult.Success();
    }
}