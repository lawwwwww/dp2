using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cafe_POS_Application.Models;
using Microsoft.AspNetCore.Hosting;

namespace Cafe_POS_Application.Controllers
{
    public class MenuController : Controller
    {
        private readonly DbContextModel _context;

        public MenuController(DbContextModel context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Menus.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
            return RedirectToAction("Index", "Menu");
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Menu menu = _context.Menus.Where(s => s.FoodCode == id).First();
                _context.Menus.Remove(menu);
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
            return View(_context.Menus.Where(s => s.FoodCode == id).First());
        }

        [HttpPost]
        public ActionResult UpdateMenu(Menu menu)
        {
            Menu d = _context.Menus.Where(s => s.FoodCode == menu.FoodCode).First();
            d.DishName = menu.DishName;
            d.Drinks = menu.Drinks;
            d.Description = menu.Description;
            d.Price = menu.Price;
            _context.SaveChanges();
            return RedirectToAction("Index", "Menu");
        }


    }

}