using System;
using System.Collections.Generic;
using System.Text;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidMobileTest
    {
        [Theory]
        [InlineData("9127536545")]
        [InlineData("0912753654")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidMobileAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("09127536545")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidMobileAttribute();
            Assert.True(attr.IsValid(value));
        }
    }
}
