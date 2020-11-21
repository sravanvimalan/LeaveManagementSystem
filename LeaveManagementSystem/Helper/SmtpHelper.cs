using LeaveManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Helper
{
    public  class SmtpHelper
    {
        
        public static void SendLeaveRequestEmailAlert(string leaveStatus,string toAddress,string recipientName)
        {
            SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SmtpHost"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FromAddress"],
               ConfigurationManager.AppSettings["Password"]);


            if (leaveStatus == "Accept")
            {
                smtp.Send(ConfigurationManager.AppSettings["FromAddress"], toAddress,
               "Your Leave Status", "Hi " + recipientName + "," + "\n\n\nYour leave request approved.");
            }
            else
            {
                smtp.Send(ConfigurationManager.AppSettings["FromAddress"], toAddress ,
              "Your Leave Status", "Hi " + recipientName + "," + "\n\n\nYour leave request rejected.");
            }
        }
    }
}
