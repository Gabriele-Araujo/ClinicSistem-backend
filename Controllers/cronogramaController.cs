using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.CronogramaDto;
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
    public class cronogramaController : ControllerBase
    {
        private CronogramaService _cronogramaService;
        public cronogramaController(CronogramaService cronogramaService)
        {
            _cronogramaService = cronogramaService;
        }

        [HttpPost]
        public IActionResult AdicionaCronograma([FromBody] CreateCronogramaDto cronogramaDto)
        {
            ReadCronogramaDto readDto = _cronogramaService.AdicionaCronograma(cronogramaDto);
            if (readDto == null) return NoContent();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCronogramas()
        {
            List<ReadCronogramaDto> readDto = _cronogramaService.RecuperaCronogramas();
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCronogramasPorId(int id)
        {
            ReadCronogramaDto readDto = _cronogramaService.RecuperaCronogramasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCronograma(int id, [FromBody] UpdateCronogramaDto cronogramaDto)
        {
            Result resultado = _cronogramaService.AtualizaCronograma(id, cronogramaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCronograma(int id)
        {
            Result resultado = _cronogramaService.DeletaCronograma(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
