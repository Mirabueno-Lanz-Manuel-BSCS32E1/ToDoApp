 using Microsoft.EntityFrameworkCore;

namespace Todolist.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDo> ToDoS { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        //seed datasdfns

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = "work", Name = "Work" },
                    new Category { CategoryId = "home", Name = "Home" },
                    new Category { CategoryId = "ex", Name = "Exercise" },
                    new Category { CategoryId = "shop", Name = "Shopping" },
                    new Category { CategoryId = "school", Name = "School" },
                    new Category { CategoryId = "anime", Name = "Anime" },
                    new Category { CategoryId = "movie", Name = "Movie" }


                );

            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "open", Name = "Open" },
                new Status { StatusId = "closed", Name = "Completed" }
                );
        }
    }
}