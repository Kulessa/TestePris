using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories
{
    public class BairroRepository : RepositoryBase<Bairro>, IBairroRepository
    {
        public BairroRepository(AppDbContext context) : base(context) { }
        public new void Update(Bairro entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
    }
}
