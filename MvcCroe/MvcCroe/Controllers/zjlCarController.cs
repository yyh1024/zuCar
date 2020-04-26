using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCroe.Controllers
{
    public class zjlCarController : Controller
    {
        public IActionResult Reserve()
        {
            return View();
        }
    }
}