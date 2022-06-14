using escolaNc.Interfaces;
using escolaNc.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratacaoController : Controller
    {
        private readonly IContratacaoService _contratacaoService;
        public ContratacaoController(IContratacaoService contratacaoService)
        {
            _contratacaoService = contratacaoService;
        }


        [HttpGet, Route("contratacao")]
        public IActionResult RetornaContratados()
        {
            try
            {
                return Ok(_contratacaoService.RetornaContratados());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{cpf}")]
        public IActionResult ContratadosCpf(string cpf)
        {
            try
            {
                return Ok(_contratacaoService.ContratadosCpf(cpf));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("servicos")]
        public IActionResult RetornaServicos()
        {
            try
            {
                return Ok(_contratacaoService.RetornaServicos());
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult ContrataServicos([FromBody] List<Contratados> lista)
        {
            try
            {
                return Ok(_contratacaoService.ContrataServicos(lista));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id_servicos_contratados}")]
        public IActionResult RemoveContratacao(int id_servicos_contratados)
        {
            try
            {
                return Ok(_contratacaoService.RemoveContratacao(id_servicos_contratados));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
