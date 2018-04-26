using Microsoft.EntityFrameworkCore;
using Targets.Domain.Implementations;

namespace Targets.Infrastructure.EF
{
    public class TargetsContext:DbContext
    {
        public TargetsContext(DbContextOptions<TargetsContext> options)
           : base(options)
        { }
        public DbSet<Step> Step { get; set; }

    }
}
