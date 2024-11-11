using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Customer;
using FarmControl.Features.Queries.Customer.CustomerViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.QueryControllers;

[Route("/api/customers")]
public class CustomerQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] CustomerFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetCustomerViewModel>>> response = await sender.Send(new GetCustomerViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetCustomerDetailViewModel> response = await sender.Send(new GetCustomerDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}