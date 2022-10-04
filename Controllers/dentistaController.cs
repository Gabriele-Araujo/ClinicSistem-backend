using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.DentistaDto;
using ClinicSistem_backend.Models;
using ClinicSistem_backend.Services;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class dentistaController : ControllerBase
    {
        private DentistaService _dentistaService;
        public dentistaController(DentistaService dentistaService)
        {
            _dentistaService = dentistaService;
        }

        [HttpPost]
        public IActionResult AdicionaDentista([FromBody] CreateDentistaDto dentistaDto)
        {
            ReadDentistaDto readDto = _dentistaService.AdicionaDentista(dentistaDto);
            if (readDto == null) return NoContent();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult RecuperaDentistas()
        {
            List<ReadDentistaDto> readDto = _dentistaService.RecuperaDentistas();
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaDentistasPorId(int id)
        {
            ReadDentistaDto readDto = _dentistaService.RecuperaDentistasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDentista(int id, [FromBody] UpdateDentistaDto dentistaDto)
        {
            Result resultado = _dentistaService.AtualizaDentista(id, dentistaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDentista(int id)
        {
            Result resultado = _dentistaService.DeletaDentista(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
