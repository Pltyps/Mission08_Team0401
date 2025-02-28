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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskId = 1, TaskName = "Finish Homework", DueDate = DateTime.Now.AddDays(2), Quadrant = 2, Category = "School", Completed = false },
                new TaskItem { TaskId = 2, TaskName = "Grocery Shopping", DueDate = DateTime.Now.AddDays(1), Quadrant = 3, Category = "Home", Completed = false },
                new TaskItem { TaskId = 3, TaskName = "Prepare Sunday School Lesson", DueDate = DateTime.Now.AddDays(3), Quadrant = 1, Category = "Church", Completed = false }
            );
        }
    }
}
