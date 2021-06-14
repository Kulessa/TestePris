using System.Collections.Generic;

#nullable disable

namespace CristianKulessa.Locadora.BackOffice.WebApi.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Imovel = new HashSet<Imovel>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }
    }
}
