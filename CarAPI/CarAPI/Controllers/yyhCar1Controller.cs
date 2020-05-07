using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;

namespace CarAPI.Controllers
{
    //[EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
    [EnableCors("first")]
    [ApiController]
    public class yyhCar1Controller : ControllerBase
    {
        CarBll bll = new CarBll();
        //添加故障原因
        [HttpPost]
        public int AddBreakdown(Breakdown m)
        {
            return bll.AddBreakdown(m);
        }
    }
}