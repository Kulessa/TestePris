using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;
using CristianKulessa.Locadora.BackOffice.WebApi.RequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("cors1")]
    public class ImovelController : ControllerBase
    {
        private readonly ILogger<ImovelController> logger;
        private readonly IImovelRepository repository;
        private readonly ITipoRepository tipoRepository;
        private readonly IUFRepository ufRepository;
        private readonly ICidadeRepository cidadeRepository;
        private readonly IBairroRepository bairroRepository;

        public ImovelController(
            ILogger<ImovelController> logger,
            IImovelRepository repository,
            ITipoRepository tipoRepository,
            IUFRepository ufRepository,
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository)
        {
            this.logger = logger;
            this.repository = repository;
            this.tipoRepository = tipoRepository;
            this.ufRepository = ufRepository;
            this.cidadeRepository = cidadeRepository;
            this.bairroRepository = bairroRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dados = repository.Select().Select(p => new
                {
                    p.Id,
                    p.Alugado,
                    p.Area,
                    p.BairroId,
                    p.Cep,
                    p.CidadeId,
                    p.Complemento,
                    p.Condominio,
                    p.Dormitorios,
                    p.Endereco,
                    p.Numero,
                    p.Suites,
                    p.TipoId,
                    p.Ufid,
                    p.VagasCarro,
                    p.Valor
                }).OrderBy(p => p.Valor).ToList();
                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var dados = repository.Select(id);
                var item = new
                {
                    dados.Id,
                    dados.Alugado,
                    dados.Area,
                    dados.BairroId,
                    dados.Cep,
                    dados.CidadeId,
                    dados.Complemento,
                    dados.Condominio,
                    dados.Dormitorios,
                    dados.Endereco,
                    dados.Numero,
                    dados.Suites,
                    dados.TipoId,
                    dados.Ufid,
                    dados.VagasCarro,
                    dados.Valor
                };
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet("tipo/{id}")]
        public IActionResult GetByTipo(int id)
        {
            try
            {
                var imoveis = repository.Select().Where(p => p.TipoId == id).OrderBy(p => p.Valor).ToList();
                var tipos = tipoRepository.Select().ToList();
                var ufs = ufRepository.Select().ToList();
                var cidades = cidadeRepository.Select().ToList();
                var bairros = bairroRepository.Select().ToList();

                var dados = imoveis.Join(tipos, i => i.TipoId, t => t.Id, (i, t) => new
                {
                    i.Id, Tipo = t.Nome, i.Alugado, i.Condominio, i.Valor, i.ValorTotal, i.Dormitorios, i.Suites,
                    i.VagasCarro, i.Area, i.Cep, i.Ufid, i.CidadeId, i.BairroId, i.Endereco, i.Numero, i.Complemento
                }).Join(ufs, i=>i.Ufid, u=>u.Id, (i,u)=>new {
                    i.Id, i.Tipo, i.Alugado, i.Condominio, i.Valor, i.ValorTotal, i.Dormitorios, i.Suites, i.VagasCarro,
                    i.Area, i.Cep, Uf = u.Sigla, i.CidadeId, i.BairroId, i.Endereco, i.Numero, i.Complemento
                }).Join(cidades, i=>i.CidadeId, c=>c.Id, (i, c) => new {
                    i.Id, i.Tipo, i.Alugado, i.Condominio, i.Valor, i.ValorTotal, i.Dormitorios, i.Suites, i.VagasCarro,
                    i.Area, i.Cep, i.Uf, Cidade = c.Nome, i.BairroId, i.Endereco, i.Numero, i.Complemento
                }).Join(bairros, i => i.BairroId, b => b.Id, (i, b) => new {
                    i.Id, i.Tipo, i.Alugado, i.Condominio, i.Valor, i.ValorTotal, i.Dormitorios, i.Suites, i.VagasCarro,
                    i.Area, i.Cep, i.Uf, i.Cidade,Bairro = b.Nome, i.Endereco, i.Numero, i.Complemento
                });

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public IActionResult Post(ImovelRequest item)
        {
            try
            {
                repository.Insert(Bind(item));
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(ImovelRequest item)
        {
            try
            {
                repository.Update(Bind(item));
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        private Imovel Bind(ImovelRequest item)
        {
            return new Imovel() { 
                Alugado =  item.Alugado,
                Area = item.Area,
                BairroId = item.BairroId,
                Cep=item.Cep,
                CidadeId = item.CidadeId,
                Complemento = item.Complemento,
                Condominio = item.Condominio,
                Dormitorios = item.Dormitorios,
                Endereco = item.Endereco,
                Id = item.Id,
                Numero =  item.Numero,
                Suites = item.Suites,
                TipoId = item.TipoId,
                Ufid = item.UfId,
                VagasCarro = item.VagasCarro,
                Valor = item.Valor
            };
        }
    }
}
