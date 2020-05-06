using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using Microsoft.AspNetCore.Cors;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("first")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        UserBll userBll = new UserBll();
        // GET: api/UserLogin
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserLogin/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        /// <summary>
        /// 用户登录方法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        // POST: api/UserLogin
        [HttpPost]
        public IActionResult ULogin([FromBody]Users m)
        {
             int ret=userBll.Login(m);
            return new JsonResult(ret);
        }

        // PUT: api/UserLogin/5
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
