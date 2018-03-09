﻿using Xunit;
using static Xunit.Assert;

namespace Dime.Utilities.Core.Tests
{
    public class StringUtilitiesTests
    {
        [Theory]
        [Trait("Category", "String")]
        [InlineData("Supercalifragilisticexpialidocious", false)]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData(" ", false)]
        public void NullIfEmpty(string sub, bool mustBeNull)
        {
            string nullIfEmptyString = sub.NullIfEmpty();
            True((nullIfEmptyString == null) == mustBeNull);
        }

        [Theory]
        [Trait("Category", "String")]
        [InlineData("Supercalifragilisticexpialidocious", false)]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData(" ", true)]
        public void NullIfEmptyOrWhiteSpace(string sub, bool mustBeNull)
        {
            string nullIfEmptyString = sub.NullIfEmptyOrWhiteSpace();
            True((nullIfEmptyString == null) == mustBeNull);
        }

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Empty_Null_Text_ReturnsText()
            => True(StringUtilities.Coalesce("", null, "Hi") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Empty_Empty_Text_ReturnsText()
            => True(StringUtilities.Coalesce("", "", "Hi") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Empty_Empty_Text_Text_ReturnsFirstText()
            => True(StringUtilities.Coalesce("", "", "Hi", "Ho") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Text_Null_Text_ReturnsFirstText()
            => True(StringUtilities.Coalesce("Hi", "", "Ha", "Ho") == "Hi");
    }
}