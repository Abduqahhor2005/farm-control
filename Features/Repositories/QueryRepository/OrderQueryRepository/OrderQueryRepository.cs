using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;
namespace FarmControl.Features.Repositories.QueryRepository.OrderQueryRepository;

public class OrderQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Order>(context),IOrderQueryRepository;