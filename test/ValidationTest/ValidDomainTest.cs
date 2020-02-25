using Validation.Annotations;
using Xunit;
namespace ValidationTest
{
    public class ValidDomainTest
    {
        [Theory]
        [InlineData("https://")]
        [InlineData(".com")]
        public void Should_Return_False(string value)
        {
            var attr = new ValidDomainAttribute();
            Assert.False(attr.IsValid(value));
        }

        [Theory]
        [InlineData("localhost:40053/index")]
        [InlineData("http:\\localhost:40053")]
        [InlineData("meyou.com")]
        public void Should_Return_True(string value)
        {
            var attr = new ValidDomainAttribute();
            Assert.True(attr.IsValid(value));
        }
    }
}
