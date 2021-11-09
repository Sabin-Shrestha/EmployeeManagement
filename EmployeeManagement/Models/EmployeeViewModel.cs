using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class EmployeeViewModel

    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        // Foreign key   
        [ForeignKey("DepartmentId")]
        public virtual DepartmentViewModel Departments { get; set; }

        [Display(Name = "Department")]
        public virtual int DepartmentId { get; set; }
    }
}