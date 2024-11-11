using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.CommandRepository.OrderCommandRepository;

public class OrderCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Order>(context),IOrderCommandRepository;