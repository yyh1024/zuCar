using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class AdminisLoginBLL
    {
        AdminisLoginDAL  AdminisLogin = new AdminisLoginDAL();
        /// <summary>
        /// 显示全部用户
        /// </summary>
        /// <returns></returns>
        public List<Admins> AdminsShow()
        {

            return AdminisLogin.AdminsShow();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddAdmins(Admins m)
        {

            return AdminisLogin.AddAdmins(m);
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int Login(Admins m)
        {

            return AdminisLogin.Login(m);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AlterAdmins(Admins m)
        {

            return AdminisLogin.AlterAdmins(m);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int DelAdmins(string id)
        {

            return AdminisLogin.DelAdmins(id);
        }
        /// <summary>
        ///  发送邮件验证码
        /// </summary>
        /// <param name="RecEmailAddress">收件人邮箱地址</param>
        /// <returns></returns>
        public string SendMailMessage(string Email)
        {
            return AdminisLogin.SendMailMessage(Email);
        }
    }
}
