using System;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class NotNullOrDefaultTest
    {
        [Theory]
        [InlineData(default(object))]
        [InlineData(default(int))]
        [InlineData(default(long))]
        [InlineData(default(double))]
        public void Should_Fail_ForDefaults(object defaultValue)
        {
            var result = new RequiredNoneDefault().IsValid(defaultValue);

            Assert.False(result);
        }

        [Fact]
        public void Should_Fail_ForNullableTypes()
        {
            var values = new object[] { (long?)null, null, (Guid?)Guid.Empty, (Guid?)null, Guid.Empty };
            foreach (var item in values)
            {
                var result = new RequiredNoneDefault().IsValid(item);
                Assert.False(result);
            }
        }
    }
}
