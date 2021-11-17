using System;
using System.Collections.Generic;
using System.Linq;
using WebApi2.Models;

namespace WebApi2.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid()
               ,Name ="Employee one"
            },
            new Employee()
            {
                Id = Guid.NewGuid()
               ,Name ="Employee Two"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EdditEmployee(Employee employee)
        {
            var existingemployee = GetEmployee(employee.Id);
            existingemployee.Name = employee.Name;
            return existingemployee;
	
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id==id);
        }

        public List<Employee> GetEmployees()
        {
           return employees;
        }
    }
}
