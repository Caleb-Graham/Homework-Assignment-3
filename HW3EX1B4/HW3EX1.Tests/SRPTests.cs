using HW3EX1B4.Model;
using HW3EX1B4.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace HW3EX1.Tests
{
    // This is confusing to me since most of these methods aren't actually doing anything. They're only implementation is to throw exceptions. That's why I'm testing for that
    // I understand how to Unit Test methods that aren't void. However these pose a whole different problem that I'm not sure I'm handling correctly.
    [TestClass]
    public class SRPTests
    {

        #region Checkout Tests


        [TestMethod]
        public void CheckoutAreEqualTest()
        {
            var paymentDetails = new PaymentDetails();

            paymentDetails.PaymentMethod = (PaymentMethod)1;  // Explicit Cast? I also just tried PaymentMethod.CreditCard but that didn't work either


            Assert.AreSame(PaymentMethod.CreditCard, paymentDetails);

        }





        #endregion

        #region ChargeCard Tests

        [TestMethod]
        [ExpectedException(typeof(AvsMismatchException))]   // Found on stack overflow. Could not use assert on void method
        public void ChargeThrowsExceptionTest()
        {
            // Arrange
            var paymentDetails = new PaymentDetails();
            var paymentGateway = new PaymentGateway();
            var cart = new Cart();

            // Act
            paymentGateway.Credentials = "account credentials";
            paymentGateway.CardNumber = paymentDetails.CreditCardNumber;
            paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
            paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
            paymentGateway.NameOnCard = paymentDetails.CardholderName;
            paymentGateway.AmountToCharge = cart.TotalAmount;

            paymentGateway.Charge();

            //Assert

        }


        [TestMethod]
        public void ChargeCardIsInstanceOfTypeTest()
        {
            // Arrange
            List<PaymentGateway> expectedCredentials = new List<PaymentGateway>();


            // Act
            expectedCredentials.Add(new PaymentGateway()
            {
                Credentials = "account credential",
                CardNumber = "1234",
                ExpiresMonth = "December",
                ExpiresYear = "2021",
                NameOnCard = "Ben Franklin",
                AmountToCharge = 2345.33m
            });


            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(expectedCredentials, typeof(PaymentGateway));

        }


        #endregion

        #region ReserveInventory Tests

        [TestMethod]
        [ExpectedException(typeof(InsufficientInventoryException))]   // Found on stack overflow. Could not use assert on void method
        public void ReserveInventoryThrowsExceptionTest(Cart cart)
        {
            var item = new OrderItem();
            var inventorySystem = new InventorySystem();

            item.Sku = "Dog";
            item.Quantity = 2;


            inventorySystem.Reserve(item.Sku, item.Quantity);

        }


        [TestMethod]
        public void ReserveInventoryIsInstanceOfTypeTest()
        {
            // Arrange
            var item = new OrderItem();
            var inventorySystem = new InventorySystem();


            item.Sku = "Dog";
            item.Quantity = 2;


            Assert.IsInstanceOfType(item, typeof(OrderItem));

        }




        #endregion

        #region NotifyCustomer Tests

        [TestMethod]
        public void SendEmailIsInstanceOfTypeTest()
        {
            // Arrange
            Cart cart = new Cart();


            // Act
            cart.CustomerEmail = "11calebgraham@gmail.com";
            string customerEmail = cart.CustomerEmail;


            //Assert
            Assert.IsInstanceOfType(customerEmail, typeof(string));

        }

        #endregion



    }
}

