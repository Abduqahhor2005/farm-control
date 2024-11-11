using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Features.Queries.Order.OrderViewModels;

namespace FarmControl.Features.Queries.Order.OrderQueryHandler;

public class SalesReportHandler(IQueryGenericRepository<Entities.Order> queryGenericRepository)
{
    public async Task<List<SalesReportViewModel>> GenerateSalesReportAsync(DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var orders = await queryGenericRepository
            .FindAsync(o => o.OrderDate >= startDate && o.OrderDate <= endDate);

        var report = orders
            .GroupBy(o => o.ProductId)
            .Select(g => new SalesReportViewModel()
            {
                ProductId = g.Key,
                ProductName = g.First().Product.Name,
                TotalQuantitySold = g.Sum(o => o.Quantity),
                TotalRevenue = g.Sum(o => o.Quantity * o.Product.Price)
            })
            .ToList();

        return report;
    }
}