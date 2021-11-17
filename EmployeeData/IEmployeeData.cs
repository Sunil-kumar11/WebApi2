using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;

namespace WebApi2.EmployeeData
{
      public   interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee EdditEmployee(Employee employee);
    }
}
