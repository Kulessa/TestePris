using CristianKulessa.Locadora.BackOffice.WebApi.Models;
using CristianKulessa.Locadora.BackOffice.WebApi.Repositories.Interfaces;
using CristianKulessa.Locadora.BackOffice.WebApi.RequestModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CristianKulessa.Locadora.BackOffice.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("cors1")]
    public class CidadeController : ControllerBase
    {
        private readonly ILogger<CidadeController> logger;
        private readonly ICidadeRepository repository;

        public CidadeController(
            ILogger<CidadeController> logger,
            ICidadeRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dados = repository.Select().Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Ufid
                }).OrderBy(p => p.Nome).ToList();
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
                    return NotFound("Registro não existe");
                }
                var item = new
                {
                    dados.Id,
                    dados.Nome,
                    dados.Ufid
                };
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpGet("uf/{ufId}")]
        public IActionResult GetByUf(int ufId)
        {
            try
            {
                var dados = repository.Select().Where(p=>p.Ufid == ufId).Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Ufid
                }).OrderBy(p => p.Nome).ToList();
                return Ok(dados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public IActionResult Post(CidadeRequest item)
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
        public IActionResult Put(CidadeRequest item)
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
        private Cidade Bind(CidadeRequest item)
        {
            return new Cidade() { 
                Id = item.Id,
                Nome = item.Nome,
                Ufid = item.Ufid
            };
        }
    }
}
