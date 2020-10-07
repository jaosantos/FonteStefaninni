using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Dto;
using Service.Interfaces;

namespace Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet("Genero")]
        public IActionResult ConsultaListaGeneros()
        {
            var retorno = _generoService.ConsultaListaGeneros();
            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpGet("Genero/{id}")]
        public IActionResult ConsultaGenero(int id)
        {
            var retorno = _generoService.ConsultaGenero(id);
            if (retorno == null)
                return NotFound();
            
            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpPost("Genero")]
        public IActionResult InsereGenero([FromBody] GeneroDto generoDto)
        {
            if (generoDto == null)
                return BadRequest();

            var retorno = _generoService.InsereGenero(generoDto);

            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpPut("Genero")]
        public IActionResult AlteraGenero([FromBody] GeneroDto generoDto)
        {
            if (generoDto == null)
                return BadRequest();

            var retorno = _generoService.AlteraGenero(generoDto);
            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpDelete("Genero/{id}")]
        public IActionResult DeleteGenero(int id)
        {
            var retorno = _generoService.DeleteGenero(id);
            return Ok(JsonConvert.SerializeObject(retorno));
        }
    }
}