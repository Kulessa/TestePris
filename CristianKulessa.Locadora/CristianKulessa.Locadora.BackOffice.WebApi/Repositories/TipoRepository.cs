using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories
{
    public class TipoRepository : RepositoryBase<Tipo>, ITipoRepository
    {
        public TipoRepository(AppDbContext context) : base(context) { }
        public new void Update(Tipo entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
    }
}
