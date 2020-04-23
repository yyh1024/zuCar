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
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        AdminsBLL bll = new AdminsBLL();

        //车辆预定信息
        [HttpGet]
        public List<Orders> Get()
        {
            return bll.OrderShow();
        }

        //查看故障报修原因
        [HttpGet("{id}", Name = "Get")]
        public Breakdown Get(int id)
        {
            return bll.GetBreakdown(id);
        }

        //新增车辆
        [HttpPost]
        public int Post([FromBody] CarInfo c)
        {
            return bll.AddCarInfo(c);
        }

        //审批
        [HttpPut("{id}")]
        public int Put([FromBody] Va v)
        {
            return bll.UptVa(v);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
