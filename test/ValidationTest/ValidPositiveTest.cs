using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class ValidPositiveTest
    {
        [Theory]
        [InlineData(-1.5)]
        [InlineData("1")]
        public void Should_Return_False(object value)
        {
            var attr = new ValidPositiveAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData(1.2)]
        public void Should_Return_True(object value)
        {
            var attr = new ValidPositiveAttribute();
            Assert.True(attr.IsValid(value));
        }
    }
}

