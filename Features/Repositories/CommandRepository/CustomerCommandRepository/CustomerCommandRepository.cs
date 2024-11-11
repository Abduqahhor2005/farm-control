using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.CommandRepository.CustomerCommandRepository;

public class CustomerCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Customer>(context),ICustomerCommandRepository;