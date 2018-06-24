using Microsoft.EntityFrameworkCore;
using Targets.Domain.Implementations;

namespace Targets.Infrastructure.EF
{
    public class TargetsContext:DbContext
    {
        public TargetsContext(DbContextOptions<TargetsContext> options)
           : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Step> Steps { get; set; }
    }
}
