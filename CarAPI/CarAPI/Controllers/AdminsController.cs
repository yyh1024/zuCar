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
using Microsoft.AspNetCore.Hosting;

namespace ApiCore.Controllers
{
    [EnableCors("first")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        AdminsBLL bll = new AdminsBLL();
        
        //车辆预定信息
        [HttpGet]
        public PageInfo Get(int currentPage = 1, int pageSize = 2)
        {
            var list = bll.OrderShow();
            var p = new PageInfo
            {
                //总记录数
                totalCount = list.Count()
            };
            //计算总页数
            if (p.totalCount == 0)
            {
                p.totalPage = 1;
            }
            else if (p.totalCount % pageSize == 0)
            {
                p.totalPage = p.totalCount / pageSize;
            }
            else
            {
                p.totalPage = (p.totalCount / pageSize) + 1;
            }
            //纠正当前页不正确的值
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > p.totalPage)
            {
                currentPage = p.totalPage;
            }
            p.Orders = list.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
            p.currentPage = currentPage;
            return p;
        }

        //查看故障报修原因
        [HttpGet("{id}", Name = "Get2")]
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

        //修改故障状态为：报修通过
        [HttpPut("{id}")]
        public int Put([FromBody] Orders o)
        {
            return bll.UptOrdersAgree(o);
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
