using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cafe_POS_Application.Models;

namespace Cafe_POS_Application.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult order()
        {
            return View();
        }
    }
}