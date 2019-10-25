using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cafe_POS_Application.Models;
using Microsoft.AspNetCore.Hosting;

namespace Cafe_POS_Application.Controllers
{
    public class TablesController : Controller
    {
        private readonly DbContextModel _context;

        public TablesController(DbContextModel context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.Table.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTable(Tables table)
        {
            _context.Table.Add(table);
            _context.SaveChanges();
            return RedirectToAction("Index", "Tables");
        }
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                Tables table = _context.Table.Where(s => s.TableNo == id).First();
                _context.Table.Remove(table);
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
            return View(_context.Table.Where(s => s.TableNo == id).First());
        }

        [HttpPost]
        public ActionResult UpdateTable(Tables table)
        {
            Tables d = _context.Table.Where(s => s.TableNo == table.TableNo).First();
            d.Status = table.Status;
            d.Reservation = table.Reservation;
            d.ReservationDate = table.ReservationDate;
            _context.SaveChanges();
            return RedirectToAction("Index", "Tables");
        }


    }

}