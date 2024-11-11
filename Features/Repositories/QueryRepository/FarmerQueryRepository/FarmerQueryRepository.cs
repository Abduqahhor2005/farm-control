using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;
namespace FarmControl.Features.Repositories.QueryRepository.FarmerQueryRepository;

public class FarmerQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Farmer>(context),IFarmerQueryRepository;