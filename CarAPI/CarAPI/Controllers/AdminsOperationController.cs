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
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]//修改路由
    [ApiController]
    public class AdminsOperationController : ControllerBase
    {
        AdminisLoginBLL AdminisLogin = new AdminisLoginBLL();
        // GET: api/AdminsOperation
        [HttpGet]
        public IEnumerable<Admins> Get()
        {
            return AdminisLogin.AdminsShow();
        }

        // GET: api/AdminsOperation/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/AdminsOperation
        [HttpPost]
        public int Post([FromBody] Admins m)
        {
            return AdminisLogin.AddAdmins(m);
        }

        // PUT: api/AdminsOperation/5
        [HttpPut("{id}")]
        public int Put([FromBody] Admins m)
        {
            return AdminisLogin.AlterAdmins(m);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return AdminisLogin.DelAdmins(id);
        }
        [HttpGet]
        public string SendMailMessage(string Email)
        {
            return AdminisLogin.SendMailMessage(Email);
        }
    }
}
