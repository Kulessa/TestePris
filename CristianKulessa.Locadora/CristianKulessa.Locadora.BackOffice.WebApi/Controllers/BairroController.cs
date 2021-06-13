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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var dados = repository.Select(id);
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
        [HttpGet("cidade/{cidadeId}")]
        public IActionResult GetByCidade(int cidadeId)
        {
            try
            {
                var dados = repository.Select().Where(p=>p.CidadeId == cidadeId).Select(p => new
                {
                    p.Id,
                    p.CidadeId,
                    p.Nome
                }).OrderBy(p => p.Nome).ToList();
                return Ok(dados);
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
