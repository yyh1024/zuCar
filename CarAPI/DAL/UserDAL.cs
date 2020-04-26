using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Linq;
using System.Net;
using System.Net.Mail;


namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 显示全部用户
        /// </summary>
        /// <returns></returns>
        public List<Users> UserShow()
        {
            string sql = "select *from Users";
            return DBHelper.GetToList<Users>(sql);
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AddUsers(Users m)
        {
            string str = $"insert into Users values('{m.Name}','{m.Pwd}','{m.Email}')";
            return DBHelper.ExecuteNonQuery(str);
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Login(Users m)
        {
            SendMailMessage(m.Email);
            string sql = "select count(1) from Users where Name='" + m.Name + "' and Pwd='" + m.Pwd + "' and Email='" + m.Email + "'";
            return (int)DBHelper.ExecuteScalar(sql);
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int AlterUsers(Users m)
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
        //邮箱验证码功能
        /// <summary>
        ///  生成随机验证码
        /// </summary>
        public string CreateRandomMailCode()
        {
            int randNum;
            char code;
            string randomCode = String.Empty;//随机验证码

            //生成一定长度的随机验证码       
            for (int i = 0; i < 6; i++)
            {
                //利用GUID生成6位随机数      
                byte[] buffer = Guid.NewGuid().ToByteArray();//生成字节数组
                int seed = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
                Random random = new Random(seed);//以生成的整数作为随机种子
                randNum = random.Next();

                //randNum = random.Next();                
                if (randNum % 3 == 1)
                {
                    code = (char)('A' + (char)(randNum % 26));//随机大写字母
                }
                else if (randNum % 3 == 2)
                {
                    code = (char)('a' + (char)(randNum % 26));//随机小写字母
                }
                else
                {
                    code = (char)('0' + (char)(randNum % 10));//随机数字
                }
                randomCode += code.ToString();
            }
            return randomCode;
        }


        /// <summary>
        ///  发送邮件验证码
        /// </summary>
        /// <param name="Email">收件人邮箱地址</param>
        /// <returns></returns>
        public bool SendMailMessage(string Email)
        {
            string code = CreateRandomMailCode();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("643241336@qq.com", "【车百汇】");//发件人邮箱地址
            mail.To.Add(new MailAddress(Email));//收件人邮箱地址
            mail.Subject = "【车百汇系统】";//邮件标题
            mail.SubjectEncoding = Encoding.UTF8;//标题编码
            mail.Body = "这封信是由 -【百车汇租赁】-官方 发送的。\r\n\r\n您的验证码为：" + code + "\r\n\r\n您收到这封" +
                  "邮件，是由于在 -【百车汇租赁】-官网 获取了新用户注册/用户登录时使用了这个邮箱地址。如果您并没有访问过 -【百车汇租赁】-" +
                  "官网，或没有进行上述操作，请忽略这封邮件。\r\n\r\n您不需要退订或进行其他进一步的操作。";//邮件内容     
            mail.BodyEncoding = Encoding.UTF8;//正文编码
            mail.Priority = MailPriority.High;//优先级

            SmtpClient client = new SmtpClient();//qq邮箱:smtp.qq.com；126邮箱:smtp.126.com              
            client.Host = "smtp.qq.com";
            //client.Host = "smtp.163.com";
            //client.Host = "smtp.163.com";
            client.Port = 587;//SMTP端口465或587
            client.EnableSsl = true;//使用安全加密SSL连接  
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("643241336@qq.com", "hgtpkkbqibcgbahg");//验证发件人身份(发件人邮箱，邮箱授权码);          
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }
    }
}
