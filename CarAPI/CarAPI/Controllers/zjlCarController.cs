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
    [EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
    [ApiController]
    public class zjlCarController : ControllerBase
    {
        CarBll bll = new CarBll();

        //所有汽车显示
        // GET: api/zjlCar
        [HttpGet]
        public IEnumerable<CarInfo> Get()
        {
            return bll.CarShow();
        }


        //汽车详情
        // GET: api/zjlCar/5
        [HttpGet("{id}", Name = "Get")]
        public CarInfo Get(int id)
        {
            return bll.Find(id);
        }




        //// POST: api/zjlCar
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/zjlCar/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
