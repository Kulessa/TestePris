using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        public CidadeRepository(AppDbContext context) : base(context) { }
        public new void Update(Cidade entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
    }
}
