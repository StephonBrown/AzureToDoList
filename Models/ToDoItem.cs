using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    [Table("ToDo")]
    public class ToDoItem
    {
        public long Id { get; set; }
        [Required]        
        public string TaskDescription { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:MM/DD/YYYY}")]
        public DateTime DateCompleted { get; set; }

        public ToDoItem(string taskDescription, DateTime DateCreated)
        {
            TaskDescription = taskDescription;
            DateCompleted = DateCreated;
            IsCompleted = false;
        }
    }
}
