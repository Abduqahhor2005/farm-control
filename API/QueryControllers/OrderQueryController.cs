using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using FarmControl.Features.Queries.Order;
using FarmControl.Features.Queries.Order.OrderViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FarmControl.API.QueryControllers;

[Route("/api/orders")]
public class OrderQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrderFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetOrderViewModel>>> response = await sender.Send(new GetOrderViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetOrderDetailViewModel> response = await sender.Send(new GetOrderDetailViewModelRequest(id));
        return response.ToActionResult();
    }
    
    [HttpGet("/salesreport/StartDate={startDate}&&EndDate={endDate}")]
    public async Task<IActionResult> Get(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        Result<PagedResponse<IEnumerable<SalesReportViewModel>>> response = await sender.Send(new GetSalesReportViewModel(startDate,endDate));
        return response.ToActionResult();
    }
}