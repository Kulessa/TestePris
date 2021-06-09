using System;
using System.Linq;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces
{
    public interface IRepositoryBase
    {
        public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
        {
            void Delete(int id);
            bool Exists(int id);
            void Insert(TEntity entity);
            IQueryable<TEntity> Select();
            TEntity Select(int id);
            void Update(TEntity entity);
        }
    }
}
