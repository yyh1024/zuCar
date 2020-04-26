using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using DAL;
using Microsoft.AspNetCore.Cors;

namespace ApiCore.Controllers
{
    //[EnableCors("any")] //跨域配置
    [Route("api/[controller]")]
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

        //// GET: api/UserLogin/5
        //[HttpGet("{id}", Name = "Get2")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/UserLogin
        [HttpPost]
        public int Post([FromBody] Users m)
        {
            MailVeriCodeClass.SendMailMessage(m.Email);
            return userBll.Login(m);
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
