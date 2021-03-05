using HW3EX1B4.Utility;
using System;
using System.Net.Mail;

namespace HW3EX1B4.Model
{
    public class SendToCustomer
    {

        public static void SendEmail(Cart cart)
        {
            string customerEmail = cart.CustomerEmail;
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

            }
        }

        public void SendText()
        {
        }












    }
}