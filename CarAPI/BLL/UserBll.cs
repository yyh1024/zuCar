using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class UserBll
    {
        UserDAL userDAL = new UserDAL();
        /// <summary>
        /// 显示全部用户
        /// </summary>
        /// <returns></returns>
        public List<Users> UserShow()
        {

            return userDAL.UserShow();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddUsers(Users m)
        {

            return userDAL.AddUsers(m);
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Login(Users m)
        {

            return userDAL.Login(m);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AlterUsers(Users m)
        {

            return userDAL.AlterUsers(m);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int DelUsers(string id)
        {

            return userDAL.DelUsers(id);
        }
    }
}
