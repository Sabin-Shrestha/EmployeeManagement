using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagement
{
    public class EmployeeManagementDBContext :DbContext
    {
        public EmployeeManagementDBContext() : base("name=DefaultConnection")
        {
            
        }

        public DbSet<EmployeeViewModel> Employee { get; set; }
        public DbSet<DepartmentViewModel> Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}