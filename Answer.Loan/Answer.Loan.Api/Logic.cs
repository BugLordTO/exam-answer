using Answer.Loan.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Loan.Api
{
    public class Logic
    {
        public IEnumerable<PrincipalDetail> CalculatePrincipal(double principal, int year, double interestPercentage)
        {
            var principalDetails = Enumerable.Empty<PrincipalDetail>().ToList();
            for (int i = 1; i <= year; i++)
            {
                var currentPrincipal = principalDetails.LastOrDefault()?.NewPrincipal ?? principal;
                var interest = CalculateInterest(currentPrincipal, interestPercentage);
                principalDetails.Add(new PrincipalDetail
                {
                    InterestPercentage = interestPercentage,
                    Year = i,
                    Principal = currentPrincipal,
                    Interest = interest,
                    NewPrincipal = currentPrincipal + interest,
                });
            }

            return principalDetails;
        }

        public double CalculateInterest(double principal, double interestPercentage)
        {
            var interest = (principal * interestPercentage) / 100;

            return Math.Round(interest, 2);
        }
    }
}
