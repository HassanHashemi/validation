using System;
using Validation.Annotations;
using Xunit;
namespace ValidationTest
{
    public class ValidEmailTest
    {
        [Theory]
        [InlineData("@me@you.com")]
        [InlineData("te.com")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidEmailAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("me@you.com")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidEmailAttribute();
            Assert.True(attr.IsValid(value));
        }

    }
}
