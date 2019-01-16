using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Loan.Api
{
    public class Logic
    {
        public double CalculateNewPrincipal(double principal, int year, double interestPercentage)
        {
            var newPrincipal = principal;
            for (int i = 0; i < year; i++)
            {
                var interest = CalculateInterest(newPrincipal, interestPercentage);
                newPrincipal += interest;
            }

            return newPrincipal;
        }

        public double CalculateInterest(double principal, double interestPercentage)
        {
            var interest = (principal * interestPercentage) / 100;

            return Math.Round(interest, 2);
        }
    }
}
