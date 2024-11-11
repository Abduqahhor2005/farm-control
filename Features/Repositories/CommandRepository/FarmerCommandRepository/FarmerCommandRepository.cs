using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.CommandRepository.FarmerCommandRepository;

public class FarmerCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Farmer>(context),IFarmerCommandRepository;