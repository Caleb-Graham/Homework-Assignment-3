using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW3EX1B4.Model
{
    public class PointOfSaleTransaction : Order
    {

        public override void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.Cash)
            {
                PaymentMethods.TakeCash(paymentDetails, cart);


                if (notifyCustomer)
                {
                    SendToCustomer.SendEmail(cart);
                }
            }
        }





    }
}
