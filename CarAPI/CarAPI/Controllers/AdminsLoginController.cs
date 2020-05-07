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
    [EnableCors("first")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsLoginController : ControllerBase
    {
        AdminisLoginBLL AdminisLogin = new AdminisLoginBLL();
        [HttpGet]
        public IEnumerable<Admins> Get()
        {
            return AdminisLogin.AdminsShow();
        }

        // GET: api/AdminsLogin/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/AdminsLogin
        [HttpPost]
        public IActionResult Post([FromBody]Admins m)
        {
            int ret = AdminisLogin.Login(m);
            return new JsonResult(ret);
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
