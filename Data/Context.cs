using Microsoft.EntityFrameworkCore;

namespace Tarefas.App.Data
{
    public class Context : DbContext
    {
        public DbSet<Task> Tarefas { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasKey(t => t.Id)
                .HasAnnotation("Sqlite:Autoincrement", true);
        }
    }
}