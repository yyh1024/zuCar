using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcCroe.Controllers
{
    public class yyhCarController : Controller
    {
        //个人实名认证
        public IActionResult AddUserInfo()
        {
            return View();
        }
        //个人订单记录显示列表
        public IActionResult OrdersShow()
        {
            return View();
        }
    }
}