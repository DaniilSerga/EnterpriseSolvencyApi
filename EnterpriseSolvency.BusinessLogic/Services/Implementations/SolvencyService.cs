using EnterpriseSolvency.BusinessLogic.Services.Contracts;
using EnterpriseSolvency.Model;
using EnterpriseSolvency.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolvency.BusinessLogic.Services.Implementations
{
    public class SolvencyService(ApplicationContext context) : ISolvencyService
    {
        private readonly ApplicationContext _context = context;

        public List<SolvencyResult> GetSolvencyHistory()
        {
            List<SolvencyResult> SolvencyHistory = [.. _context.SolvencyHistory.AsNoTracking()];

            if (SolvencyHistory.Count == 0)
            {
                return [];
            }

            return SolvencyHistory;
        }

        public async void CreateSolvency(SolvencyResult solvency)
        {
            ArgumentNullException.ThrowIfNull(solvency);

            await _context.SolvencyHistory.AddAsync(solvency);
            _context.SaveChanges();
        }

        public async void DeleteSolvency(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }

            using ApplicationContext db = _context;

            SolvencyResult? solvency = db.SolvencyHistory.FirstOrDefault(result => result.Id == id);

            if (solvency != null)
            {
                //удаляем объект
                db.SolvencyHistory.Remove(solvency);
                db.SaveChanges();
            }
        }
    }
}
