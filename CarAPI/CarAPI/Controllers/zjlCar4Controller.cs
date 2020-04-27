using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class zjlCar4Controller : ControllerBase
    {
        CarBll bll = new CarBll();

        //个人订单显示
        // GET: api/zjlCar4
        [HttpGet]
        public IEnumerable<Orders> Get(int UsersId)
        {
            return bll.OrdersShow(UsersId);
        }







        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
