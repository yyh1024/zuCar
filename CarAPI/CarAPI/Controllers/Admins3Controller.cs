using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Cors;

namespace ApiCore.Controllers
{
    //[EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
    [ApiController]
    public class Admins3Controller : ControllerBase
    {
        AdminsBLL bll = new AdminsBLL();

        // GET: api/Admins3
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Admins3/5
        //[HttpGet("{id}", Name = "Get2")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Admins3
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //修改故障状态为：有待商议
        [HttpPut("{id}")]
        public int Put([FromBody] Orders o)
        {
            return bll.UptOrdersDisAgree(o);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
