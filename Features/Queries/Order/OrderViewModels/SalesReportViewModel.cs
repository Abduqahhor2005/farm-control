using FarmControl.Base.Extensions.PatternResultExtensions;
using FarmControl.Base.Responses;
using MediatR;

namespace FarmControl.Features.Queries.Order.OrderViewModels;

public readonly record struct SalesReportViewModel(
    int ProductId,
    string ProductName,
    int TotalQuantitySold,
    decimal TotalRevenue);

public record GetSalesReportViewModel(DateTimeOffset StartDate, DateTimeOffset EndDate) : IRequest<Result<PagedResponse<IEnumerable<SalesReportViewModel>>>>;
    
    