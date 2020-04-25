using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using BLL;
using Microsoft.AspNetCore.Cors;
using DAL;

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
        public List<Users> Get()
        {
            return userBll.UserShow();
        }
        //[HttpPost]
        //public string GetRandomMailCode()
        //{
        //    return MailVeriCodeClass.CreateRandomMailCode();
        //}

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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[HttpGet("VerifyCode")]
        //public async Task GetVerifyCode()
        //{
        //    Response.ContentType = "image/jpeg";
        //    using (var stream = VerifyCodeHelper.Create(out string code))
        //    {
        //        var buffer = stream.ToArray();
        //        // 将验证码的token放入cookie
        //        Response.Cookies.Append(VERFIY_CODE_TOKEN_COOKIE_NAME, await SecurityServices.GetVerifyCodeToken(code));
        //        await Response.Body.WriteAsync(buffer, 0, buffer.Length);
        //    }
        //}

    }
}
