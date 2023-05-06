using Microsoft.EntityFrameworkCore;

namespace Tarefas.App.Data
{
    public class Context : DbContext
    {
        public DbSet<TaskModel> Tarefas { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasKey(t => t.Id)
                .HasAnnotation("Sqlite:Autoincrement", true);
        }
    }
}