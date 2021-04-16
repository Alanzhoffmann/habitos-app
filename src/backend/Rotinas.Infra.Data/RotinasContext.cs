using Microsoft.EntityFrameworkCore;

namespace Rotinas.Infra.Data
{
    public class RotinasContext : DbContext
    {
        public RotinasContext(DbContextOptions<RotinasContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RotinasContext).Assembly);
        }
    }
}
