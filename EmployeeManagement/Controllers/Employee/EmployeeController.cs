using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        private EmployeeManagementDBContext db = new EmployeeManagementDBContext();

        // GET: Employee
        public ActionResult Index()
        {
             
            return View(db.Employee.ToList());

        }                                 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel testViewModel = db.Employee.Find(id);


            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }
        // GET: Test/Create
        public ActionResult Create()
        {
            //var VinyardQry = from d in db.Department
            //                 orderby d.DepartmentName
            //                 select new { d.DepartmentId, d.DepartmentName };

            ViewBag.DepartmentList = new SelectList(db.Department, "DepartmentId", "DepartmentName");//the soure of dropdownlist
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Address,ContactNo,Email,DepartmentId")] EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                
                    db.Employee.Add(employeeViewModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }

            //ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentName", employeeViewModel.DepartmentId);//book.Author_id sets pre-options of dropdownlist

            //ViewBag.Author_id = new SelectList(db.authors, "Author_id", "Name", book.Author_id);//book.Author_id sets pre-options of dropdownlist

            //ViewBag.VinyardLst = new SelectList(db.Department, "DepartmentId", "DepartmentName");//the soure of dropdownlist
            ViewBag.DepartmentList = new SelectList(db.Department, "DepartmentId", "DepartmentName", employeeViewModel.DepartmentId);//book.Author_id sets pre-options of dropdownlist

            return View(employeeViewModel);
        }

        //public ActionResult Edit(int? id)
        //{
        //    return View();
        //}


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel testViewModel = db.Employee.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.DepartmentList = new SelectList(db.Department, "DepartmentId", "DepartmentName");//the soure of dropdownlist


            return View(testViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Address,ContactNo,Email,DepartmentId")] EmployeeViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentList = new SelectList(db.Department, "DepartmentId", "DepartmentName", testViewModel.DepartmentId);//book.Author_id sets pre-options of dropdownlist

            return View(testViewModel);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel testViewModel = db.Employee.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeViewModel testViewModel = db.Employee.Find(id);

            db.Employee.Remove(testViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

    }



    }

