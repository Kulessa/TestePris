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
    public class BairroController : ControllerBase
    {
        private readonly ILogger<BairroController> logger;
        private readonly IBairroRepository repository;

        public BairroController(
            ILogger<BairroController> logger,
            IBairroRepository repository)
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
                    p.CidadeId,
                    p.Nome
                }).OrderBy(p => p.Nome).ToList();
                if (dados == null || dados.Count == 0)
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
                var item = new
                {
                    dados.Id,
                    dados.CidadeId,
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
        public IActionResult Post(Bairro item)
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
        public IActionResult Put(Bairro item)
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
