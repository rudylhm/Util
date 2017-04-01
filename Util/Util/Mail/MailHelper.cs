using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Util.Mail
{
    public class MailHelper
    {
        //定义邮件服务器及系统账户信息
        //private static String MailHost = "smtp.qq.com";
        //private static String SenderAddress = "doyogame@qq.com";
        //private static String SenderPassword = "Duoyoukeji@Rudy1";

        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">收件人</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isBodyHtml"></param>
        public static void Send(string SenderAddress, string SenderPassword, string MailHost, string mailToArrayStr, string subject, string body, bool isBodyHtml, byte[] attachmentContent = null, string attachmentName = "")
        {
            //定义邮件消息对象
            var mailMessage = new MailMessage { From = new MailAddress(SenderAddress) };

            string[] mailToArray = mailToArrayStr.Split(',');

            foreach (string mailTo in mailToArray)
            {
                //添加到收件人列表中
                mailMessage.To.Add(mailTo);
            }

            //构造主题和内容
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;
            if (attachmentContent != null)
            {
                MemoryStream ms = new MemoryStream(attachmentContent);
                mailMessage.Attachments.Add(new Attachment(ms, attachmentName));
            }
            //初始化邮件发送客户端
            var smtp = new SmtpClient(MailHost)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(SenderAddress, SenderPassword)
            };


            //发送邮件
            smtp.Send(mailMessage);
        }
        #endregion
    }
}
