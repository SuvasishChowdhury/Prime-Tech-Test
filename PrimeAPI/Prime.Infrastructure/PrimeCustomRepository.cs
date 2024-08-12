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
    public class PrimeCustomRepository<T> : IPrimeCustomRepository<T> where T : Company
    {
        private readonly PrimeDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public PrimeCustomRepository(PrimeDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.ID == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
