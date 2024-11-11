using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.CommandRepository.ProductCommandRepository;

public class ProductCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Product>(context),IProductCommandRepository;