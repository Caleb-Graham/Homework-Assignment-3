using HW3EX1B4.Model;
using HW3EX1B4.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW3EX1.Tests
{
    [TestClass]
    public class SRPTests
    {

        #region ChargeCard Tests

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var paymentDetails = new PaymentDetails();
            var paymentGateway = new PaymentGateway();
            var cart = new Cart();
            PaymentGateway check;

            // Act
            paymentGateway.Credentials = "account credentials";
            paymentGateway.CardNumber = paymentDetails.CreditCardNumber;
            paymentGateway.ExpiresMonth = paymentDetails.ExpiresMonth;
            paymentGateway.ExpiresYear = paymentDetails.ExpiresYear;
            paymentGateway.NameOnCard = paymentDetails.CardholderName;
            paymentGateway.AmountToCharge = cart.TotalAmount;

            check = paymentGateway.Charge();

            //Assert
            Assert.ThrowsException()

        }














        #endregion

    }
}
