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
    public class TipoController : ControllerBase
    {
        private readonly ILogger<TipoController> logger;
        private readonly ITipoRepository repository;

        public TipoController(
            ILogger<TipoController> logger,
            ITipoRepository repository)
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
                    p.Nome
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
                    dados.Nome
                };
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        public IActionResult Post(TipoRequest item)
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
        public IActionResult Put(TipoRequest item)
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
        private Tipo Bind(TipoRequest item)
        {
            return new Tipo() { 
                Id = item.Id,
                Nome = item.Nome
            };
        }
    }
}
