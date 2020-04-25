using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Model;
using BLL;
using Microsoft.AspNetCore.Cors;

namespace ApiCore.Controllers
{
    [EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
    [ApiController]
    public class zjlCar3Controller : ControllerBase
    {

        CarBll bll = new CarBll();
        //个人信息认证显示
        // GET: api/zjlCar3
        [HttpGet]
        public IEnumerable<UserInfo> Get(int  UsersId)
        {
            return bll.UserInfoShow(UsersId);
        }

        // GET: api/zjlCar3/5
        [HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //个人信息认证 （用添加来做认证）
        // POST: api/zjlCar3
        [HttpPost]
        public int Post(UserInfo u)
        {
            return bll.AddUserInfo(u);
        }

        // PUT: api/zjlCar3/5
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
