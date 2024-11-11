using Microsoft.EntityFrameworkCore;

namespace FarmControl.Base.Data;

public sealed class AppQueryDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);