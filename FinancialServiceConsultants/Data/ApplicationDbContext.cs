using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinancialServiceConsultants.Models;

namespace FinancialServiceConsultants.Data
{
    //
    // Examples - Commandline Tools for EF Core
    // -------------------------------------------------------------------------------------------------------------
    //  - add-migration    -project FinancialServiceConsultants -OutputDir Data/Migrations
    //  - update-database  -project FinancialServiceConsultants <migrationname>
    //  - remove-migration -project FinancialServiceConsultants 

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}

