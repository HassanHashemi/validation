
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public  class ValidPersianTest
    {
        [Theory]
        [InlineData("فارسیa")]
        [InlineData("فا-رسي")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidPersianAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("محمّد علي")]
        [InlineData("محمد علی")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidPersianAttribute();
            Assert.True(attr.IsValid(value));
        }

    }
}
