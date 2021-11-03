using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;
using System.Data.SqlClient;
using WebApplication8.Controllers;


namespace WebApplication8.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var employees = repo.GetAllEmployees();
            return View(employees);
        }

        public IActionResult InsertEmployee(Employee employeeToInsert)
        {
            repo.InsertEmployee(employeeToInsert);

            return View();
        }




        public IActionResult Login()
        {



            return View();
        }
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        void connectoinString()
        {
            con.ConnectionString = "Server = localhost; Database = users; uid = root; Pwd = password; Port = 3306;";
        }
     
        [HttpPost]
        public ActionResult Authorize(Employee  emp)
        {
            connectoinString();
            con.Open();
            com.Connection = con;
            com.CommandText =" select * from users.users where Username='"+emp.Username+"' and password = '"+emp.Password+ "' ";
            con.Close();
            SqlDataReader dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Success");
            }else
            {
                con.Close();
                return View();
            }


            
        }
    }
}
