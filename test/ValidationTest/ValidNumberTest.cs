using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidNumberTest
    {
        [Theory]
        [InlineData("0 1")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidNumberAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("02")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidNumberAttribute();
            Assert.True(attr.IsValid(value));
        }
    }
}
