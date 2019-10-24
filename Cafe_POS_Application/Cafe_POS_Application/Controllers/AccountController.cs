using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Cafe_POS_Application.Models;

namespace Cafe_POS_Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbContextModel _context;
        public AccountController(DbContextModel context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Validate(Employee employee)
        {
            var _employee = _context.Employees.Where(s => s.Email == employee.Email);
            if (_employee.Any())
            {
                if (_employee.Where(s => s.Password == employee.Password).Any())
                {
                    return Json(new { status = true, message = "Login Successfull!" });

                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }
        }
    }
}