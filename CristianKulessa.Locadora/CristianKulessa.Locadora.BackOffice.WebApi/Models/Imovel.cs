using System;
using System.Collections.Generic;

#nullable disable

namespace CristianKulessa.Locadora.BackOffice.WebApi.Models
{
    public partial class Imovel
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int Ufid { get; set; }
        public int CidadeId { get; set; }
        public int BairroId { get; set; }
        public bool Alugado { get; set; }
        public int Dormitorios { get; set; }
        public int Suites { get; set; }
        public int VagasCarro { get; set; }
        public string Cep { get; set; }
        public decimal Area { get; set; }
        public decimal Condominio { get; set; }
        public decimal Valor { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public decimal? ValorTotal { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual Uf Uf { get; set; }
    }
}
