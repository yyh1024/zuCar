using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using DAL;

namespace ApiCore.Controllers
{
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

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public int Post([FromBody] Users m)
        {
            MailVeriCodeClass.SendMailMessage(m.Email);
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
    }
}
