using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Loan.Api.Models
{
    public class PrincipalDetail
    {
        public double InterestPercentage { get; set; }
        public int Year { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        public double NewPrincipal { get; set; }
    }
}
