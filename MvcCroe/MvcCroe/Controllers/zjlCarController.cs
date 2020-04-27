using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCroe.Controllers
{
    public class zjlCarController : Controller
    {
        //车辆预定
        public IActionResult Reserve()
        {
            return View();
        }

        //车辆挂靠
        public IActionResult AddVa()
        {
            return View();
        }

    }
}