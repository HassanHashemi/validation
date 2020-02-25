using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidDateTest
    {
        [Theory]
        [InlineData("1397-01-01")]
        [InlineData("1397/13/01")]
        [InlineData(@"1397\01\01")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidDateAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("1397/12/01")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidDateAttribute();
            Assert.True(attr.IsValid(value));
        }

    }
}
