
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public  class ValidSpecialCharactersTest
	{
        [Theory]
        [InlineData("فارسیa*")]
        [InlineData("فا-رسي")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidOnlyAlphaNumericAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("محمّد علي 123")]
        [InlineData("محمد علی adf")]
		[InlineData("محمد علی adf 123")]
		public void Should_Return_True(string value)
        {
            var attr = new ValidOnlyAlphaNumericAttribute();
            Assert.True(attr.IsValid(value));
        }
    }
}
