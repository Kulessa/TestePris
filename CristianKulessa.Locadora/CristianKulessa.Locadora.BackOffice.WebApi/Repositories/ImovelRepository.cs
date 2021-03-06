using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Repositories
{
    public class ImovelRepository : RepositoryBase<Imovel>, IImovelRepository
    {
        public ImovelRepository(AppDbContext context) : base(context) { }
        public new void Update(Imovel entity)
        {
            DetachLocal(x => x.Id == entity.Id);
            base.Update(entity);
        }
    }
}
