using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;
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

        public ImovelController(
            ILogger<ImovelController> logger,
            IImovelRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dados = repository.Select().OrderBy(p=>p.Valor).ToList();
                if (dados == null && dados.Count == 0)
                {
                    return NotFound();
                }
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
                if (dados == null)
                {
                    return NotFound();
                }
                var item = new { 
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
                    dados.Tipo, 
                    dados.TipoId, 
                    dados.Uf, 
                    dados.Ufid, 
                    dados.VagasCarro, 
                    dados.Valor };
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
                var dados = repository.Select().Where(p => p.TipoId == id).OrderBy(p => p.Valor).ToList();
                if (dados == null && dados.Count == 0)
                {
                    return NotFound();
                }
                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public IActionResult Post(Imovel item)
        {
            try
            {
                repository.Insert(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPut]
        public IActionResult Put(Imovel item)
        {
            try
            {
                repository.Update(item);
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

    }
}
