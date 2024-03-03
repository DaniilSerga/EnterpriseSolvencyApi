using EnterpriseSolvency.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolvency.BusinessLogic.Services.Contracts
{
    public interface ISolvencyService
    {
        List<SolvencyResult> GetSolvencyHistory();
        void CreateSolvency(SolvencyResult solvency);
        void DeleteSolvency(int id);
    }
}
