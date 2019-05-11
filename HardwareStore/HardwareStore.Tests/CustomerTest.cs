using HardwareStore.Library;
using System;
using Xunit;

namespace HardwareStore.Tests
{
    public class CustomerTest
    {
        private readonly Customer cust = new Customer();

        [Fact]
        public void FName_NonEmptyValue_StoresCorrectly()
        {
            const string randomNameValue = "Bob";
            cust.FirstName = randomNameValue;
            Assert.Equal(randomNameValue, cust.FirstName);
        }

        [Fact]
        public void FName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => cust.FirstName = string.Empty);
        }

        [Fact]
        public void LName_NonEmptyValue_StoresCorrectly()
        {
            const string randomNameValue = "Smith";
            cust.LastName = randomNameValue;
            Assert.Equal(randomNameValue, cust.LastName);
        }

        [Fact]
        public void LName_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => cust.LastName = string.Empty);
        }

        [Fact]
        public void Phone_EmptyValue_Throws_Exception()
        {
            Assert.ThrowsAny<ArgumentException>(() => cust.PhoneNumber = string.Empty);
        }

        [Fact]
        public void Phone_NonEmptyValue_StoresCorrectly()
        {
            const string randomNameValue = "1112223333";
            cust.PhoneNumber = randomNameValue;
            Assert.Equal(randomNameValue, cust.PhoneNumber);
        }

        [Fact]
        public void Phone_IncorrectFormatValue_Throws_Exception()
        {
            Assert.ThrowsAny<ArgumentException>(() => cust.PhoneNumber = "1112223ddd333");
        }
    }
}
