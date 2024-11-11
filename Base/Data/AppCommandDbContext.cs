using Microsoft.EntityFrameworkCore;

namespace FarmControl.Base.Data;

public sealed class AppCommandDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);