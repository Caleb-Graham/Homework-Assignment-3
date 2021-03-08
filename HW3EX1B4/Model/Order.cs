using System;
using System.Net.Mail;
using HW3EX1B4.Services;
using HW3EX1B4.Utility;

namespace HW3EX1B4.Model
{

    // I need to increase cohesion. All my methods need to focus on a single task
    // I need to reduce coupling. This method should not rely on the other modules if I can help it
    public class Order
    {
        public virtual void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            // I tried to remove the direct method calls from this method and reduce couling in return
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard)
            {
                PaymentMethods.ChargeCard(paymentDetails, cart);

                InventorySystem.ReserveInventory(cart);

                if (notifyCustomer)  // I'm not sure why you would need to test a boolean
                {
                    SendToCustomer.SendEmail(cart);
                }
            }
        }


    }
}

    public class OrderException : Exception
    {
        public OrderException(string message, Exception innerException)
            : base(message, innerException)
        {            
        }
    }