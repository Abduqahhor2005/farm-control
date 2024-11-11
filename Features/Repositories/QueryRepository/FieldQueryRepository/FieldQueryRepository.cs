using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;
namespace FarmControl.Features.Repositories.QueryRepository.FieldQueryRepository;

public class FieldQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Field>(context),IFieldQueryRepository;