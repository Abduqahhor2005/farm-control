using FarmControl.Base.BaseRepository.BaseQueryGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.QueryRepository.ChatQueryRepository;

public class ChatQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Chat>(context),IChatQueryRepository;