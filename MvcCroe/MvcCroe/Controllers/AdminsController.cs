using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCroe.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult OrderShow()
        {
            return View();
        }

        public IActionResult VaShow()
        {
            return View();
        }

        public IActionResult AddCarInfo()
        {
            return View();
        }

        public IActionResult UptVa()
        {
            return View();
        }

        public IActionResult UptOrdersAgree()
        {
            return View();
        }

        public IActionResult UptOrdersDisAgree()
        {
            return View();
        }
    }
}