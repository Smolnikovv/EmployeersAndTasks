using System.Collections.Generic;

namespace EmployersAndTasks.Models
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}