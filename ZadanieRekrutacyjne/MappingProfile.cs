using AutoMapper;
using EmployersAndTasks.Entities;
using EmployersAndTasks.Models;

namespace EmployersAndTasks
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            
            CreateMap<Task, TaskDto>();

            CreateMap<Employee, AddEmployeeDto>();

            CreateMap<Task, AddTaskDto>();
        }
    }
}
