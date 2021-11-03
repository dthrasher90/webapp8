using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using WebApplication8.Models;
using Dapper;

namespace WebApplication8
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly IDbConnection _conn;

        public EmployeeRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("Select * from users.users;");
        }

        public void InsertEmployee(Employee employeeToInsert)
        {
            _conn.Execute("INSERT INTO users.users ( FIRSTNAME, LASTNAME, USERNAME, PASSWORD ) VALUES ( @firstname, @lastname, @username, @password);",
               new { id=employeeToInsert.Id,  firstname = employeeToInsert.FirstName, lastname = employeeToInsert.LastName, username = employeeToInsert.Username, password= employeeToInsert.Password });


         }

        public void Submit_Click()
        {
            Console.WriteLine("clik clik clik");
        }
}
}
