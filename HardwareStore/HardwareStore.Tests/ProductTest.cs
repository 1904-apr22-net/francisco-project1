using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HardwareStore.Library;

namespace HardwareStore.Tests
{
    public class ProductTest
    {
        private readonly Products prod = new Products();

        [Fact]
        public void ProductName_EmptyValue_Throws_Exception()
        {
            Assert.ThrowsAny<ArgumentException>(() => prod.ProductName = string.Empty);
        }

        [Fact]
        public void ProductName_NonEmptyValue_StoresCorrectly()
        {
            const string randomNameValue = "Bananananana";
            prod.ProductName = randomNameValue;
            Assert.Equal(randomNameValue, prod.ProductName);
        }
    }
}
