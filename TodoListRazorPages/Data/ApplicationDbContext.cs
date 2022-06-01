using Microsoft.EntityFrameworkCore;

namespace TodoListRazorPages.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem() { Id = 1, Title = "Eat", IsDone = true },
                new TodoItem() { Id = 2, Title = "Pray", IsDone = false },
                new TodoItem() { Id = 3, Title = "Love", IsDone = true },
                new TodoItem() { Id = 4, Title = "Run", IsDone = false }
                );
        }
    }
}
