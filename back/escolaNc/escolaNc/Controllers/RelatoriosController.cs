using escolaNc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace escolaNc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatoriosService _relService;
        public RelatoriosController(IRelatoriosService relService)
        {
            _relService = relService;
        }
        [HttpGet, Route("faturamento")]
        public IActionResult Faturamento()
        {
            return Ok(_relService.ServicosContratados());
        }

        //[HttpGet, Route("inadimplentes/")]
        // public IActionResult InadimplentesCpf(string cpf)
        // {
        //     try
        //     {
        //         return Ok(_relService.InadimplentesCpf(cpf));
        //     }
        //     catch (Exception e)
        //     {

        //         return BadRequest(e.Message);
        //     }
        // }
        [HttpGet, Route("inadimplentes/{cpf=}")]
        public IActionResult Inadimplentes(string cpf)
        {
            try
            {
                return Ok(_relService.Inadimplentes(cpf));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
