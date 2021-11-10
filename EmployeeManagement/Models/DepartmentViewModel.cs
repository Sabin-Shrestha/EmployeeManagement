using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            employeeViewModel = new List<EmployeeViewModel>();
        }
        [Key]
        public int DepartmentId { get; set; } 
        public string DepartmentName { get; set; }
        public int DepartmentNo { get; set; }
        public List<EmployeeViewModel> employeeViewModel { get; set; }

    }

}