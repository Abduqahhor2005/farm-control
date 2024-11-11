using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Order.OrderCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.CommandControllers;

[Route("/api/orders")]
public class OrderCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeleteOrderRequest(id));
        return result.ToActionResult();
    }
}