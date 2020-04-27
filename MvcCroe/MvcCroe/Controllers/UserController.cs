using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCroe.Controllers
{
    public class UserController : Controller
    {
        public IActionResult LoginUser()
        {
            return View();
        }
        //个人实名认证
        public IActionResult AddUserInfo()
        {
            return View();
        }
    }
}