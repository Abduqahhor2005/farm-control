using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Order.OrderCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.OrderCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Order.OrderCommandHandler;

public class UpdateOrderHandler(IOrderCommandRepository orderCommandRepository):IRequestHandler<UpdateOrderRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Entities.Order?> existingOrders = await orderCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Entities.Order order = existingOrders.FirstOrDefault()!;
        if (order is null) return BaseResult.Failure(Error.None());

        int res = await orderCommandRepository.UpdateAsync(order.ToUpdatedOrder(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Order not updated !!!"))
            : BaseResult.Success();
    }
}