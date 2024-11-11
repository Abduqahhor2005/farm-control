using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;
namespace FarmControl.Features.Repositories.QueryRepository.ProductQueryRepository;

public class ProductQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Product>(context),IProductQueryRepository;