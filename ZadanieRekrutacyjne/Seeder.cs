using System.Collections.Generic;
using System.Linq;
using System;
using EmployersAndTasks.Entities;

namespace EmployersAndTasks
{
    public class Seeder
    {
        private readonly RecruitmentTaskDbContext dbContext;

        public Seeder(RecruitmentTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            if(dbContext.Database.CanConnect())
            {
                if (!dbContext.Employees.Any())
                {
                    List<Employee> employees = Employees();
                    dbContext.Employees.AddRange(employees);
                    dbContext.SaveChanges();
                }          
            }
        }
        private List<Employee> Employees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Jan",
                    Surname = "Kowalski",
                    Email = "jankowalski@test.com",
                    Position = "PROJECT MANAGER",
                    Tasks = new List<Task>()
                    {
                        new Task()
                        {
                            Name = "Test1",
                            Description = "Description of test1 task",
                            DateTime = new DateTime(2022,4,14),
                            Status = "NEW",
                        },
                        new Task()
                        {
                            Name = "Test2",
                            Description = "Description of test2 task",
                            DateTime = new DateTime(2022,10,14),
                            Status = "IN PROGRES",
                        },
                        new Task()
                        {
                            Name = "Test3",
                            Description = "Description of test3 task",
                            DateTime = new DateTime(2022,5,20),
                            Status = "TO SPECIFY",
                        }
                    }
                },
                new Employee()
                {
                    Name = "Andrzej",
                    Surname = "Nowak",
                    Email = "andrzejnowak@test.com",
                    Position = "QA",
                    Tasks = new List<Task>()
                    {
                        new Task()
                        {
                            Name = "Test1",
                            Description = "Description of test1 task",
                            DateTime = new DateTime(2022,1,1),
                            Status = "REOPENED",
                        },
                        new Task()
                        {
                            Name = "Test2",
                            Description = "Description of test2 task",
                            DateTime = new DateTime(2022,2,3),
                            Status = "TO TEST",
                        },
                    }
                },
                new Employee()
                {
                    Name = "Marcin",
                    Surname = "Smoleń",
                    Email = "marcinsmolen@test.com",
                    Position = "PROGRAMISTA",
                    Tasks = new List<Task>()
                    {
                        new Task()
                        {
                            Name = "Test1",
                            Description = "Description of test1 task",
                            DateTime = new DateTime(2022,1,1),
                            Status = "COMPLETED",
                        },
                        new Task()
                        {
                            Name = "Test2",
                            Description = "Description of test2 task",
                            DateTime = new DateTime(2022,2,3),
                            Status = "CANCELED",
                        },
                    }
                }
            };
            return employees;
        }
    }
}
