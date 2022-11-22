
using System.Collections.Generic;

namespace EmployersAndTasks.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
