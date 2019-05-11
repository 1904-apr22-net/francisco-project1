using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HardwareStore.Library;

namespace HardwareStore.Tests
{
    public class LocationTest
    {
        private readonly Location loc = new Location();

        [Fact]
        public void Name_NonEmptyValue_StoresCorrectly()
        {
            const string randomNameValue = "Wallmartio";
            loc.Name = randomNameValue;
            Assert.Equal(randomNameValue, loc.Name);
        }

        [Fact]
        public void Name_EmptyValue_ThrowsArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => loc.Name = string.Empty);
        }


    }
}
