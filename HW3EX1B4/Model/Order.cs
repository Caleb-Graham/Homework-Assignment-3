using System;
using System.Net.Mail;
using HW3EX1B4.Services;
using HW3EX1B4.Utility;

namespace HW3EX1B4.Model
{
    // A class should have onle one reason to change.
    // This means that the Order class needs to be soley focused on orders and only have one responsibility

    // I need to increase cohesion. All my methods need to focus on a single task
    // I need to reduce coupling. This method should not rely on the other modules if I can help it
    public class Order
    {
        public virtual void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {

            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard)
            {
                PaymentMethods.ChargeCard(paymentDetails, cart);

                ReserveInventory(cart);

                if (notifyCustomer)
                {
                    SendToCustomer.SendEmail(cart);
                }
            }
        }


        public void ReserveInventory(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                try
                {
                    var inventorySystem = new InventorySystem();
                    inventorySystem.Reserve(item.Sku, item.Quantity);

                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.Sku, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
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