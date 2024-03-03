using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolvency.Model.Models
{
    public class SolvencyResult
    {
        public int Id { get; set; }
        public double StartFunds { get; set; }
        public double EndFunds { get; set; }
        public double SpentFunds { get; set; }
        public double CalculationResult { get; set; }
        public string Description { get; set; } = "";
    }
}
