using System.Collections.Generic;

#nullable disable

namespace CristianKulessa.Locadora.BackOffice.WebApi.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Bairro = new HashSet<Bairro>();
        }

        public int Id { get; set; }
        public int Ufid { get; set; }
        public string Nome { get; set; }

        public virtual Uf Uf { get; set; }
        public virtual ICollection<Bairro> Bairro { get; set; }
    }
}
