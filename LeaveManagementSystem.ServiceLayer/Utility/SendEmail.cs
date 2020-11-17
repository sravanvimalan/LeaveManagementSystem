using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.ServiceLayer.Utility
{
    public class SendEmail
    {
        IEmployeeService employeeService;
public SendEmail(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public void SendMail()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;


            smtp.Credentials = new NetworkCredential("forapptestpurpose@gmail.com",
               "tvokfhzelmfawwel");
            //EmployeeViewModel empProfile = employeeService.GetEmployeeByID(adminReply.CreatedBy);

            //if (adminReply.LeaveStatus == "Accept")
            //{
            //    smtp.Send("forapptestpurpose@gmail.com", empProfile.EmailID,
            //   "Your Leave Status", "Hi " + empProfile.FirstName + " " + empProfile.MiddleName + " " + empProfile.LastName + "," + "\n\n\nYour leave request approved.");
            //}
            //else
            //{
            //    smtp.Send("forapptestpurpose@gmail.com", empProfile.EmailID,
            //  "Your Leave Status", "Hi " + empProfile.FirstName + " " + empProfile.MiddleName + " " + empProfile.LastName + "," + "\n\n\nYour leave request rejected.");
            //}
        }
    }
}
