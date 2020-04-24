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

namespace ApiCore.Controllers
{
    [EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
    [ApiController]
    public class Admins2Controller : ControllerBase
    {
        AdminsBLL bll = new AdminsBLL();

        //用户挂靠的车辆信息
        [HttpGet]
        public List<Va> Get()
        {
            return bll.VaShow();
        }

        // GET: api/Admins2/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admins2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //修改故障状态为：报修通过
        [HttpPut("{id}")]
        public int Put([FromBody] Orders o)
        {
            return bll.UptOrdersAgree(o);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
