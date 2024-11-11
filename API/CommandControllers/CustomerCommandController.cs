using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Features.Commands.Customer.CustomerCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.CommandControllers;

[Route("/api/customers")]
public class CustomerCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeleteCustomerRequest(id));
        return result.ToActionResult();
    }
}