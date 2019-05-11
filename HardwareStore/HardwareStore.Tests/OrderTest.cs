using System;
using System.Collections.Generic;
using System.Text;
using HardwareStore.Library;
using Xunit;



namespace HardwareStore.Tests
{
    public class OrderTest
    {

        private readonly Order order = new Order();
        [Fact]
        public void CheckNegativeOrderTotal()
        {
            Assert.ThrowsAny<ArgumentException>(() => order.OrderTotal = -5);
        }

        [Fact]
        public void Check_NonNegative_Total_Stores_Correctly()
        {
            const int randomValue = 20;
            order.OrderTotal = randomValue;
            Assert.Equal(randomValue, order.OrderTotal);
        }
    }
}
