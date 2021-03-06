using System.Collections.Generic;

#nullable disable

namespace CristianKulessa.Locadora.BackOffice.WebApi.Models
{
    public partial class Bairro
    {
        public Bairro()
        {
            Imovel = new HashSet<Imovel>();
        }

        public int Id { get; set; }
        public int CidadeId { get; set; }
        public string Nome { get; set; }

        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
