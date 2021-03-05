using HW3EX1B4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3EX1B4.Model
{
    public class PaymentMethods
    {
        public static void ChargeCard(PaymentDetails paymentDetails, Cart cart)
        {
            using (var paymentGateway = new PaymentGateway())
            {
                try
                {
                    paymentGateway.Credentials = "account credentials";
                    paymentGateway.CardNumber = paymentDetails.CreditCardNumber;
                    paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
                    paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
                    paymentGateway.NameOnCard = paymentDetails.CardholderName;
                    paymentGateway.AmountToCharge = cart.TotalAmount;

                    paymentGateway.Charge();
                }
                catch (AvsMismatchException ex)
                {
                    throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("There was a problem with your card.", ex);
                }
            }
        }

        public static void TakeCash(PaymentDetails paymentDetails, Cart cart)
        {

        }


    }
}
