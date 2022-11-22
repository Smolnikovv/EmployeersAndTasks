using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using EmployersAndTasks.Entities;
using EmployersAndTasks.Exception;
using EmployersAndTasks.Models;

namespace EmployersAndTasks.Services
{
    public interface IEmployeeService
    {
        int Post(AddEmployeeDto dto);
        List<EmployeeDto> GetAll();
        EmployeeDto GetById(int id);
        void DeleteById(int id);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly RecruitmentTaskDbContext dbContext;
        private readonly IMapper mapper;

        public EmployeeService(RecruitmentTaskDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void DeleteById(int id)
        {
            Employee reuslt = dbContext
                .Employees
                .FirstOrDefault(x => x.Id == id);
            if(reuslt == null)
            {
                throw new BadRequestException("Can't found employee");
            }
            List<Task> resultTasks = dbContext
                .Tasks
                .Where(x => x.EmployeeId == id)
                .ToList();
            dbContext.Employees.Remove(reuslt);
            dbContext.Tasks.RemoveRange(resultTasks);
            dbContext.SaveChanges();
        }

        public List<EmployeeDto> GetAll()
        {
            List<Employee> result = dbContext
                .Employees
                .Include(x=>x.Tasks)
                .ToList();
            return mapper.Map<List<EmployeeDto>>(result);
        }

        public EmployeeDto GetById(int id)
        {
            Employee result = dbContext
                .Employees
                .Include(x => x.Tasks)
                .FirstOrDefault(x => x.Id == id);
            return mapper.Map<EmployeeDto>(result);
        }

        public int Post(AddEmployeeDto dto)
        {
            Employee result = mapper.Map<Employee>(dto);
            dbContext.Employees.Add(result);
            dbContext.SaveChanges();
            return result.Id;
        }
    }
}
