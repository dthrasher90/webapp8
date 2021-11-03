using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

using System.Configuration;
using System.Data;

namespace WebApplication8.Models
{
    public class Employee
    {
       

        public Employee()
        {

        }

        public int Id { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter username ")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = " Please enter password ")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Password must be longer than 5 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match please try again")]
        public string ConfirmPassword { get; set; }

      
    }
}
