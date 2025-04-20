using Microsoft.EntityFrameworkCore;

namespace DAL
{
    class AppContext(DbContextOptions<AppContext> options) : DbContext (options)
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            modelBuilder.Entity<Note>().HasKey(x => x.Id);
            modelBuilder.Entity<Note>().Property(x => x.Text).HasMaxLength(140);
            base.OnModelCreating(modelBuilder);
        }
    }
}
