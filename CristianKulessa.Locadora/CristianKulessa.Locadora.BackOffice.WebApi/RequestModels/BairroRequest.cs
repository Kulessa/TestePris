using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristianKulessa.Locadora.BackOffice.WebApi.RequestModels
{
    public class BairroRequest
    {
        public int Id { get; set; }
        public int CidadeId { get; set; }
        public string Nome { get; set; }
    }
}
