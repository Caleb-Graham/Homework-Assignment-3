using HW3EX1B4.Model;
using System;

namespace HW3EX1B4.Services
{
    public class InventorySystem
    {
        public void Reserve(string sku, int quantity)
        {
            throw new InsufficientInventoryException();
        }


        public static void CheckForInventory(Cart cart)
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


    public class InsufficientInventoryException : Exception
    {
    }
}