using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;
namespace FarmControl.Features.Repositories.QueryRepository.CustomerQueryRepository;

public class CustomerQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Customer>(context),ICustomerQueryRepository;