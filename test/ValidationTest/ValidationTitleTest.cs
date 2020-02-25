using System;
using System.Collections.Generic;
using System.Text;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidationTitleTest
    {
        [Theory]
        [InlineData("@me@you.com")]
        [InlineData("te.com")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidTitleAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("mcom")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidTitleAttribute();
            Assert.True(attr.IsValid(value));
        }
    }
}
