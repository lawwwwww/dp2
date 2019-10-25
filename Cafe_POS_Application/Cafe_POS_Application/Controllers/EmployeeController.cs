using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cafe_POS_Application.Models;
using Microsoft.AspNetCore.Hosting;

namespace Cafe_POS_Application.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbContextModel _context;

        public EmployeeController(DbContextModel context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Employee.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Employee employee = _context.Employee.Where(s => s.EmpID == id).First();
                _context.Employee.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }

        }

        public ActionResult Update(int id)
        {
            return View(_context.Employee.Where(s => s.EmpID == id).First());
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            Employee d = _context.Employee.Where(s => s.EmpID == employee.EmpID).First();
            d.EmpName = employee.EmpName;
            d.ContactInfo = employee.ContactInfo;
            d.HireDate = employee.HireDate;
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }


    }

}