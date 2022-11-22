using System;
using System.ComponentModel.DataAnnotations;
using EmployersAndTasks.Entities;

namespace EmployersAndTasks.Models
{
    public class AddTaskDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
