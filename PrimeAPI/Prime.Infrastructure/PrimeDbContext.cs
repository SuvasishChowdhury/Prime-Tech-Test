using Microsoft.EntityFrameworkCore;
using Prime.Entities;
using Prime.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Infrastructure
{
    public class PrimeDbContext : DbContext, IPrimeDbContext
    {
        public PrimeDbContext(DbContextOptions<PrimeDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Company> Companies { get; set; }



        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges(CancellationToken cancellationToken) 
        { 
            return base.SaveChanges();
        }
    }
}
