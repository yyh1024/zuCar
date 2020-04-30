using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Model;
using Microsoft.AspNetCore.Cors;

namespace ApiCore.Controllers
{
    //[EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
    [EnableCors("first")]
    [ApiController]
    public class zjlCar2Controller : ControllerBase
    {
        CarBll bll = new CarBll();

        //个人挂靠车辆显示
        // GET: api/zjlCar2
        [HttpGet]
        public IEnumerable<Va> Get(int UsersId)
        {
            return bll.VaShow(UsersId);
        }



        // GET: api/zjlCar2/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}



        //用户挂靠车辆
        // POST: api/zjlCar2
        [HttpPost]
        public int Post(Va v)
        {
            return bll.AddVa(v);
        }

        // PUT: api/zjlCar2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
