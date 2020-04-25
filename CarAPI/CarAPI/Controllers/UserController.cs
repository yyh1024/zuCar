﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class UserController : ControllerBase
    {
        UserBll userBll = new UserBll();

        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET: api/User/5
        //[HttpGet("{id}", Name = "Get2")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/User
        [HttpPost]
        public int Post([FromBody] Users m)
        {
            MailVeriCodeClass.SendMailMessage(m.Email);
            return userBll.AddUsers(m);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public int Put([FromBody]Users m)
        {
            return userBll.AlterUsers(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return userBll.DelUsers(id);
        }

        //public IActionResult RandomMailCode()
        //{
        //    return MailVeriCodeClass.CreateRandomMailCode();
        //}

    }
}
