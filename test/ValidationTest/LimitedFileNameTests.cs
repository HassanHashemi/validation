using System;
using Validation.Annotations;
using Xunit;

namespace ValidationTest
{
    public class LimitedFileNameTests
    {
        private LimitedFilesAttribute _validAttr;

        public LimitedFileNameTests()
        {
            _validAttr = new LimitedFilesAttribute(".mov", ".mp4");
        }

        [Fact]
        public void Should_Return_True()
        {
            Assert.True(_validAttr.IsValid("a.mp4"));
        }

        [Fact]
        public void Should_Return_False_ForInvalidInput()
        {
            Assert.False(_validAttr.IsValid("a.mp3"));
        }

        [Fact]
        public void Should_Throw_ForInvalidExtension()
        {
            Assert.Throws<ArgumentException>(() => new LimitedFilesAttribute("jpg", "ext"));
        }
    }
}
