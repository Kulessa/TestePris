using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces.IRepositoryBase;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<TEntity> dbSet;

        public RepositoryBase(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public void Delete(int id)
        {
            dbSet.Remove(dbSet.Find(id));
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Exists(int id)
        {
            return dbSet.Find(id) != null;
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public IQueryable<TEntity> Select()
        {
            return dbSet;
        }

        public TEntity Select(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
        public virtual void DetachLocal(Func<TEntity, bool> predicate)
        {
            var local = dbSet.Local.Where(predicate).FirstOrDefault();
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
