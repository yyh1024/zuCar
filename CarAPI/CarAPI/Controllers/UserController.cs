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
        /// <summary>
        /// postman调试显示用户信息
        /// </summary>
        /// <returns></returns>
        // GET: api/User
        [HttpGet]
        public List<Users> Get()
        {
            return userBll.UserShow();
        }
        /// <summary>
        /// 验证码传递
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string GetRandomMailCode()
        {
            return userBll.CreateRandomMailCode();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        // POST: api/User
        [HttpPost]
        public int Post([FromBody] Users m)
        {
            return userBll.AddUsers(m);
        }
        /// <summary>
        /// 用户修改信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        // PUT: api/User/5
        [HttpPut("{id}")]
        public int Put([FromBody]Users m)
        {
            return userBll.AlterUsers(m);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// 删除用户的记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public int Delete(string id)
        {
            return userBll.DelUsers(id);
        }
        /// <summary>
        /// 用户登录方法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public int LoginUser([FromBody] Users m)
        {
            return userBll.Login(m);
        }
        /// <summary>
        /// 发送邮件的方法
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        public bool SendMailMessage(string Email)
        {
            return userBll.SendMailMessage(Email);
        }
    }
}
