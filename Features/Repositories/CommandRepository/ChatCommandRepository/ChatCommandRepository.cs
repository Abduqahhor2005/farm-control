using FarmControl.Base.BaseRepository.BaseCommandGenericRepository;
using FarmControl.Base.Data;
using FarmControl.Features.Entities;

namespace FarmControl.Features.Repositories.CommandRepository.ChatCommandRepository;

public class ChatCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Chat>(context),IChatCommandRepository;