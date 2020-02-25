using System;
using System.Collections.Generic;
using System.Text;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidMaxLenght
    {
        [Theory]
        [InlineData("ali")]
        public void Should_Be_Max_True(object value)
        {
            var attr = new MaxLenghtAttribute(4);
            Assert.True(attr.IsValid(value));
        }

        [Theory]
        [InlineData("ali")]
        [InlineData(123)]
        public void Should_Be_Max_Flase(object value)
        {
            var attr = new MaxLenghtAttribute(2);
            Assert.False(attr.IsValid(value));
        }
    }
}
