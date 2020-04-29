using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;

namespace CarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsLoginController : ControllerBase
    {
        AdminisLoginBLL AdminisLogin = new AdminisLoginBLL();
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminsLogin/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/AdminsLogin
        [HttpPost]
        public int Post([FromBody]Admins m)
        {
            return AdminisLogin.Login(m);
        }

        // PUT: api/AdminsLogin/5
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
