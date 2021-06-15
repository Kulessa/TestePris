using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristianKulessa.Locadora.BackOffice.WebApi.RequestModels
{
    public class UfRequest
    {
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }

    }
}
