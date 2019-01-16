using Answer.Loan.Api;
using FluentAssertions;
using System;
using Xunit;

namespace Answer.Loan.Test
{
    public class LogicTest
    {
        [Theory]
        [InlineData(10000, 1, 11200)]
        [InlineData(10000, 2, 12544)]
        [InlineData(10000, 3, 14049.28)]
        public void Test1(double principal, int year, double expected)
        {
            var sut = new Logic();
            var actual = sut.CalculateNewPrincipal(principal, year);
            actual.Should().Be(expected);
        }
    }
}
