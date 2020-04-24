using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//发送邮件需要引用的命名空间
using System.Net.Mail;
using System.Net;
using System.Net.Mime;



using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DAL
{
    public class SendEmail
    {
        /// <summary>
        /// 邮箱验证码
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public string SendMassage(string recipient)
        {
            //创建一个随机数种子
            Random rdm = new Random();
            //初始化邮箱验证码为空字符串
            string mailCode = "";
            //这里和验证码那里一样，就不在写注释了
            string code = "1234567890loLOqwertyuipasdfghjkzxcvbnmQWERTYUIPASDFGHJKZXCVBNM";
            for (int i = 0; i < 6; i++)
            {
                mailCode += code[rdm.Next(0, code.Length)].ToString();
            }
            //实例化一个MailMessage对象用来设置邮件的信息
            MailMessage msg = new MailMessage();
            msg.To.Add(recipient);//收件人
            msg.From = new MailAddress("百车汇租赁");//发件人
            msg.Subject = "好久不见！";//标题
            msg.SubjectEncoding = Encoding.UTF8;//标题编码
                                                //正文
            msg.Body = "这封信是由 -【百车汇租赁】-官方 发送的。\r\n\r\n您的验证码为：" + mailCode + "\r\n\r\n您收到这封" +
                "邮件，是由于在 -【百车汇租赁】-官网 获取了新用户注册/用户登录地址使用 了这个邮箱地址。如果您并没有访问过 -【百车汇租赁】-" +
                "官网，或没有进行上述操作，请忽 略这封邮件。您不需要退订或进行其他进一步的操作。";
            msg.BodyEncoding = Encoding.UTF8;//正文编码
            SmtpClient client = new SmtpClient();//实例化一个邮箱客户端
            client.Host = "smtp.qq.com";//设置邮箱主机  这个是qq的，网易126为 smtp.126.com   ，这个你用那个邮箱就去百度找找
            //client.Host = "smtp.163.com";
            //client.Host = "smtp.163.com";
            client.Port = 587;//端口号
            client.EnableSsl = true;//是否ssl加密   现在好像都是加密的   所以这里一般都写true
            client.Credentials = new NetworkCredential("643241336@qq.com", "hgtpkkbqibcgbahg");//发件人@qq.com, 发件人的授权码
            try//捕获异常
            {
                client.Send(msg);
                return "成功";//没抛异常，说明发送成功
            }
            catch (Exception e)
            {
                //如果抛异常就将其异常信息返回
                return e.ToString();
            }
        }
    }
}
