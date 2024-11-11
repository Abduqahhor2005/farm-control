using FarmControl.Base.Extensions.Mappers;
using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Order.OrderCommandRequest;
using FarmControl.Features.Repositories.CommandRepository.OrderCommandRepository;
using MediatR;

namespace FarmControl.Features.Commands.Order.OrderCommandHandler;

public class CreateOrderHandler(IOrderCommandRepository orderCommandRepository):IRequestHandler<CreateOrderRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        if (request==null)
            return BaseResult.Failure(Error.None());
        int res = await orderCommandRepository.AddAsync(request.ToOrder());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Order not saved !!!"))
            : BaseResult.Success();
    }
}