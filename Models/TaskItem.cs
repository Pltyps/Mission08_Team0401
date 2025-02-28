using System;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0401.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }  // Primary key
        
        [Required]
        public string TaskName { get; set; }  // Required field
        
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }  // Nullable due date
        
        [Required]
        public int Quadrant { get; set; }  // Required, value between 1-4
        
        // Foreign key to Category
        [Required]
        public int CategoryId { get; set; }  // Foreign key reference to Category
        
        public Category Category { get; set; }  // Navigation property to Category
        
        public bool Completed { get; set; }  // True/False for completion status
    }
    
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }  // Primary key for category

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }  // The name of the category (e.g., Home, School, etc.)
    }
}
