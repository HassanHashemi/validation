using System;
using System.Collections.Generic;
using System.Text;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidMinLenght
    {
        [Theory]
        [InlineData("mohammd")]
        [InlineData("جواد")]
        public void Should_Be_Min_True(object value)
        {
            var attr = new MinLenghtAttribute(4);
            Assert.True(attr.IsValid(value));
        }

        [Theory]
        [InlineData("Ali")]
        [InlineData(1243)]
        public void Should_Be_Min_Flase(object value)
        {
            var attr = new MinLenghtAttribute(4);
            Assert.False(attr.IsValid(value));
        }
    }
}

