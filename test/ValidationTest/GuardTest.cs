using System;
using Xunit;

namespace ValidationTest
{
    public class GuardTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Throw_For_NullAndEmpty_String(string input)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.NotNullOrEmpty(input, nameof(input)));
        }

        [Theory]
        [InlineData(null)]
        public void Should_Throw_For_Null_String(string input)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.NotNull(input, nameof(input)));
        }

        [Theory]
        [InlineData("")]
        public void Should_Throw_For_Empty_String(string input)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.NotEmpty(input, nameof(input)));
        }

        [Theory]
        [InlineData("12-")]
        [InlineData("12.0")]
        public void Should_Throw_For_Invalid_Number(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidNumber(input, nameof(input)));
        }

        [Theory]
        [InlineData("@example.com")]
        [InlineData("exple@.com")]
        public void Should_Throw_For_Invalid_Email(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidEmail(input, nameof(input)));
        }

        [Theory]
        [InlineData("https://")]
        [InlineData("exple..com")]
        public void Should_Throw_For_Invalid_Domain(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidDomain(input, nameof(input)));
        }

        [Theory]
        [InlineData("0912123456")]
        [InlineData("9121234567")]
        [InlineData("08121234567")]
        public void Should_Throw_For_Invalid_Mobile(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidMobile(input, nameof(input)));
        }

        [Theory]
        //[InlineData("9999999999")]
        //[InlineData("448997060")]
        [InlineData("448-997060-9")]
        public void Should_Throw_For_Invalid_NationalCode(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidNationalCode(input, nameof(input)));
        }

        [Theory]
        [InlineData("فارسیa")]
        [InlineData("فارسی-")]
        public void Should_Throw_For_Invalid_Persian(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidPersian(input, nameof(input)));
        }

        [Theory]
        [InlineData("1395/13/12")]
        [InlineData("1395/1/32")]
        public void Should_Throw_For_Invalid_Date(string input)
        {
            Assert.Throws<ArgumentException>(() => Guard.ValidDate(input, nameof(input)));
        }

    }
}
