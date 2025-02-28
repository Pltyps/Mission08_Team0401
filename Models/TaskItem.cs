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

        [Required]
        public string Category { get; set; }  // Dropdown: Home, School, Work, Church

        public bool Completed { get; set; }  // True/False for completion status
    }
}
