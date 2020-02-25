using System;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidNationalCodeTest
    {
        [Theory]
        [InlineData("448-997060-9")]
        [InlineData("4489970608")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidNationalCodeAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("4489970609")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidNationalCodeAttribute();
            Assert.True(attr.IsValid(value));
        }

    }
}
