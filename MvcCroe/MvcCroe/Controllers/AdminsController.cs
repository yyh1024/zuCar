﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCroe.Controllers
{
    public class AdminsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}