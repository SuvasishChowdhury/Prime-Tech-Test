using Microsoft.EntityFrameworkCore;
using Prime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime.Services.Service
{
    public interface IPrimeDbContext
    {
        DbSet<Company> Companies { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChanges(CancellationToken cancellationToken = default);
    }
}
