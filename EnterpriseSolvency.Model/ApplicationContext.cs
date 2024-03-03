using EnterpriseSolvency.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EnterpriseSolvency.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SolvencyResult> SolvencyHistory { get; set; } = null!;

        public ApplicationContext()
        {
            
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
        }
    }
}
