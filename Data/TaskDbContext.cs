using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0401.Models;

namespace Mission08_Team0401.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
            
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskId = 1, TaskName = "Finish Homework", DueDate = new DateTime(2025, 3, 3), Quadrant = 2, CategoryId = 2, Completed = false },
                new TaskItem { TaskId = 2, TaskName = "Grocery Shopping", DueDate = new DateTime(2025, 3, 1), Quadrant = 3, CategoryId = 1, Completed = false },
                new TaskItem { TaskId = 3, TaskName = "Prepare Sunday School Lesson", DueDate = new DateTime(2025, 3, 4), Quadrant = 1, CategoryId = 4, Completed = false }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}

