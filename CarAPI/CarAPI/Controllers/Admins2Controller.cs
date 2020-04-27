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
    public class Admins2Controller : ControllerBase
    {
        AdminsBLL bll = new AdminsBLL();

        //用户挂靠的车辆信息
        [HttpGet]
        public PageInfo Get(int currentPage = 1, int pageSize = 3)
        {
            var list = bll.VaShow();
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
            p.Vas = list.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
            p.currentPage = currentPage;
            return p;
        }

        // GET: api/Admins2/5
        //[HttpGet("{id}", Name = "Get2")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Admins2
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
