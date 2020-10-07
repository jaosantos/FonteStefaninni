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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _FilmeService;

        public FilmeController(IFilmeService FilmeService)
        {
            _FilmeService = FilmeService;
        }

        [HttpGet("Filme")]
        public IActionResult ConsultaListaFilmes()
        {
            var retorno = _FilmeService.ConsultaListaFilmes();
            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpGet("Filme/{id}")]
        public IActionResult ConsultaFilme(int id)
        {
            var retorno = _FilmeService.ConsultaFilme(id);
            if (retorno == null)
                return NotFound();

            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpPost("Filme")]
        public IActionResult InsereFilme([FromBody] FilmeDto FilmeDto)
        {
            if (FilmeDto == null)
                return BadRequest();

            var retorno = _FilmeService.InsereFilme(FilmeDto);

            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpPut("Filme")]
        public IActionResult AlteraFilme([FromBody] FilmeDto FilmeDto)
        {
            if (FilmeDto == null)
                return BadRequest();

            var retorno = _FilmeService.AlteraFilme(FilmeDto);
            return Ok(JsonConvert.SerializeObject(retorno));
        }

        [HttpDelete("Filme/{id}")]
        public IActionResult DeleteFilme(int id)
        {
            var retorno = _FilmeService.DeleteFilme(id);
            return Ok(JsonConvert.SerializeObject(retorno));
        }

    }
}