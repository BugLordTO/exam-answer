using Answer.Loan.Api;
using FluentAssertions;
using System;
using Xunit;

namespace Answer.Loan.Test
{
    public class LogicTest
    {
        [Theory]
        [InlineData(10000, 12, 1200)]
        [InlineData(11200, 12, 1344)]
        [InlineData(12544, 12, 1505.28)]
        public void CalculateInterestTest(double principal, int interestPercentage, double expected)
        {
            var sut = new Logic();
            var actual = sut.CalculateInterest(principal, interestPercentage);
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(10000, 1, 12, 11200)]
        [InlineData(10000, 2, 12, 12544)]
        [InlineData(10000, 3, 12, 14049.28)]
        public void CalculateNewPrincipalTest(double principal, int year, double interestPercentage, double expected)
        {
            var sut = new Logic();
            var actual = sut.CalculateNewPrincipal(principal, year, interestPercentage);
            actual.Should().Be(expected);
        }
    }
}
