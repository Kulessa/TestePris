using System.Collections.Generic;

#nullable disable

namespace CristianKulessa.Locadora.BackOffice.WebApi.Models
{
    public partial class Uf
    {
        public Uf()
        {
            Cidade = new HashSet<Cidade>();
            Imovel = new HashSet<Imovel>();
        }

        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Cidade> Cidade { get; set; }
        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
