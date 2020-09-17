using FinanzasWeb.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanzasWeb.Models
{
    public class FinancistoContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public FinancistoContext(DbContextOptions<FinancistoContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}
