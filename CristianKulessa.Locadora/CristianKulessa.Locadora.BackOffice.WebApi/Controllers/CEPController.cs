using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;
using System.Xml;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("cors1")]
    public class CEPController : ControllerBase
    {
        private readonly ILogger<CEPController> logger;
        private readonly IConfiguration config;
        private readonly IUFRepository ufRepository;
        private readonly ICidadeRepository cidadeRepository;
        private readonly IBairroRepository bairroRepository;

        public CEPController(
            ILogger<CEPController> logger,
            IConfiguration config,
            IUFRepository ufRepository,
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository)
        {
            this.logger = logger;
            this.config = config;
            this.ufRepository = ufRepository;
            this.cidadeRepository = cidadeRepository;
            this.bairroRepository = bairroRepository;
        }

        [HttpGet("{cep}")]
        public object Get(string cep)
        {
            var urlWS = config.GetSection("WebServiceSettings")["WSCorreios"];
            var client = new RestClient(urlWS);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/xml; charset=utf-8");
            string strXml =
                "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:cli=\"http://cliente.bean.master.sigep.bsb.correios.com.br/\">" +
                "<soapenv:Body>" +
                "<cli:consultaCEP>" +
                "<cep>" + cep + "</cep>" +
                "</cli:consultaCEP>" +
                "</soapenv:Body>" +
                "</soapenv:Envelope>";
            request.AddParameter("application/xml", strXml, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content);
            var retornoWS = JsonConvert.DeserializeAnonymousType((JObject.Parse(JsonConvert.SerializeXmlNode(doc.GetElementsByTagName("return")[0]))["return"]).ToString().Replace("\r\n", ""), new { Bairro = "", CEP = "", Cidade = "", Complemento2 = "", End = "", UF = "" });
            var ufId = GetUFById(retornoWS.UF);
            var cidadeId = GetCidadeId(ufId, retornoWS.Cidade);
            var bairroId = GetBairroId(cidadeId, retornoWS.Bairro);
            var retorno = new
            {
                Bairro = retornoWS.Bairro,
                BairroId = bairroId,
                Cep = retornoWS.CEP,
                Cidade = retornoWS.Cidade,
                CidadeId = cidadeId,
                Complemento2 = retornoWS.Complemento2,
                Endereco = retornoWS.End,
                UF = retornoWS.UF,
                UFId = ufId
            };

            return retorno;

        }

        private int GetBairroId(int cidadeId, string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return 0;
            }
            var item = bairroRepository.Select().FirstOrDefault(p => p.CidadeId == cidadeId && p.Nome == nome);
            if (item == null)
            {
                bairroRepository.Insert(new Bairro() { CidadeId = cidadeId, Nome = nome });
                item = bairroRepository.Select().FirstOrDefault(p => p.CidadeId == cidadeId && p.Nome == nome);
            }
            return item.Id;
        }

        private int GetCidadeId(int ufId, string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return 0;
            }
            var item = cidadeRepository.Select().FirstOrDefault(p => p.Ufid == ufId && p.Nome == nome);
            if (item == null)
            {
                cidadeRepository.Insert(new Cidade() { Ufid= ufId, Nome = nome });
                item = cidadeRepository.Select().FirstOrDefault(p => p.Ufid == ufId && p.Nome == nome);
            }
            return item.Id;
        }

        private int GetUFById(string sigla)
        {
            var item = ufRepository.Select().FirstOrDefault(p => p.Sigla == sigla);
            return item != null ? item.Id : 0;
        }
    }
}
