using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.CommandRepository.FieldCommandRepository;

public class FieldCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Field>(context),IFieldCommandRepository;