using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Answer.Loan.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Answer.Loan.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private static double InterestPercentage = 12;

        private readonly Logic logic;

        public LoanController(
            Logic logic
            )
        {
            this.logic = logic;
        }

        [HttpGet("Interest/Percentage")]
        public double GetInterestPercentage()
        {
            return InterestPercentage;
        }

        [HttpPut("Interest/Percentage/{interestPercentage}")]
        public void EditInterestPercentage(double interestPercentage)
        {
            InterestPercentage = interestPercentage;
        }

        [HttpGet("Principal/{principal}/{year}")]
        public IEnumerable<PrincipalDetail> GetPrincipalByYear(double principal, int year)
        {
            var principalDetails = logic.CalculatePrincipal(principal, year, InterestPercentage);
            return principalDetails;
        }
    }
}
