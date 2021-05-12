using Dummy.API;
using System;
using Xunit;

namespace Cashbook.Tests
{
    public class BusinessRulesTests
    {
        [Fact]
        public void IsYearExpected()
        {
            var testDate = new DateTime(2021, 1, 25);
            var result = BusinessRules.IsTaxYear(testDate, 2021);
            Assert.True(result);
        }

        [Fact]
        public void IsYearUnexpected()
        {
            var testDate = new DateTime(2021, 1, 25);
            var result = BusinessRules.IsTaxYear(testDate, 2022);
            Assert.False(result);
        }

        [Fact]
        public void IsYearEdgeCases()
        {
            var testDate = new DateTime(2020, 3, 31);
            var result = BusinessRules.IsTaxYear(testDate, 2020);
            Assert.True(result);
            testDate = new DateTime(2020, 4, 1);
            result = BusinessRules.IsTaxYear(testDate, 2021);
            Assert.True(result);
        }
    }
}
