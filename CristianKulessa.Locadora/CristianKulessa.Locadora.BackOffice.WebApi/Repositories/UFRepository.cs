using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories
{
    public class UFRepository : RepositoryBase<Uf>, IUFRepository
    {
        public UFRepository(AppDbContext context) : base(context) { }
        public new void Update(Uf entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
    }
}
