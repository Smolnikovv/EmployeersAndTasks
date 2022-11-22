using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using EmployersAndTasks.Entities;
using EmployersAndTasks.Models;
using EmployersAndTasks.Exception;

namespace EmployersAndTasks.Services
{
    public interface ITaskService
    {
        int Post(AddTaskDto dto);
        void Put(string status, int id);
        List<TaskDto> GetAll(int id);
    }
    public class TaskService : ITaskService
    {
        private readonly RecruitmentTaskDbContext dbContext;
        private readonly IMapper mapper;

        public TaskService(RecruitmentTaskDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public List<TaskDto> GetAll(int id)
        {
            List<Task> result = dbContext.Tasks.Where(x=>x.EmployeeId==id).ToList();
            return mapper.Map<List<TaskDto>>(result);
        }

        public int Post(AddTaskDto dto)
        {
            Task result = mapper.Map<Task>(dto);
            dbContext.Tasks.Add(result);
            dbContext.SaveChanges();
            return result.Id;
        }

        public void Put(string status, int id)
        {
            Task result = dbContext
                .Tasks
                .FirstOrDefault(x => x.Id == id);
            if(result == null)
            {
                throw new BadRequestException("Can't found task");
            }
            result.Status = status;
            dbContext.SaveChanges();
        }
    }
}
