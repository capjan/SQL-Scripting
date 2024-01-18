using System;
using Core.SqlScripting.Common;
using Core.SqlScripting.Common.Writer.Identifier;
using Xunit;

namespace Test.Core.SqlScripting.SQLite.SQLite
{
    public class ElementTests
    {
        [Theory]
        [InlineData("'invalid")]
        [InlineData("?ahk")]
        [InlineData(" LeadingSpace")]
        [InlineData("TailingSpace ")]
        public void SafeIdentifierThrowsException(string invalidIdentifier)
        {
            var formatter = new SafeIdentifierFormatter();
            Assert.Throws<NotSupportedException>(() => formatter.WriteToString(invalidIdentifier));
        }

        [Theory]
        [InlineData("User")]
        [InlineData("Room")]
        [InlineData("permission")]
        [InlineData("_underline")]
        [InlineData("PK_User")]
        public void SafeIdentifierWritesValidValues(string validIdentifier)
        {
            var formatter = new SafeIdentifierFormatter();
            Assert.Equal(validIdentifier, formatter.WriteToString(validIdentifier));
        }
    }
}
