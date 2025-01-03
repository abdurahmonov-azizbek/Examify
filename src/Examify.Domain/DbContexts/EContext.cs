using Examify.Domain.Entities.sys;
using Microsoft.EntityFrameworkCore;

namespace Examify.Domain.DbContexts;

public class EContext(DbContextOptions<EContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
}