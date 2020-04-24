using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public class UserDAL
    {
        SendEmail email = new SendEmail();
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddUsers(User m)
        {
            email.SendMassage(m.Email);
            if (sess)
            {

            }
            string str = $"insert into Users values('{m.Name}','{m.Pwd}','{m.Email}')";
            return DBHelper.ExecuteNonQuery(str);
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Login(User m)
        {
            string sql = "select count(1) from Users where Name='" + m.Name + "' and Pwd='" + m.Pwd + "' and Email='" + m.Email + "'";
            return (int)DBHelper.ExecuteScalar(sql);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AlterUsers(User m)
        {
            string str = $"update Users set Name='{m.Name}',Pwd='{m.Pwd}',Email='{m.Email}'where Uid={m.Uid}";
            return DBHelper.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelUsers(string id)
        {
            string str = $"delete from Users where Uid in(" + id + ")";
            return DBHelper.ExecuteNonQuery(str);
        }
    }
}
