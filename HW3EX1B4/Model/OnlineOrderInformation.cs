using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using HW3EX1B4.Utility;

namespace HW3EX1B4.Model
{
    // Possibly a little broad. But for our purposes I think it suffices
    // If this started to get lengthy you could divide it up into other classes
    public class OnlineOrderInformation
    {

        public static void EmailNotification(String customerEmail)
        {
            if (!String.IsNullOrEmpty(customerEmail))
            {
                using (var message = new MailMessage("orders@somewhere.com", customerEmail))
                using (var client = new SmtpClient("localhost"))
                {
                    message.Subject = "Your order placed on " + DateTime.Now.ToString();
                    message.Body = "Your order details: \n " + customerEmail.ToString();

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Problem sending notification email", ex);
                    }
                }

                return;
            }
        }



    }
}
