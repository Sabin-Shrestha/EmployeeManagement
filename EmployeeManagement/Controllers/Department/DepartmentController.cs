using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers.Department
{
    public class DepartmentController : Controller
    {
        private EmployeeManagementDBContext db = new EmployeeManagementDBContext();

        // GET: Department
        public ActionResult Index()
        {

            return View(db.Department.ToList());

        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentViewModel testViewModel = db.Department.Find(id);


            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }


        // POST: Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(departmentViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentViewModel);
        }

    }
}