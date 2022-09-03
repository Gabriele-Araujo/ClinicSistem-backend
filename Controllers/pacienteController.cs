using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.AgendaDto;
using ClinicSistem_backend.Data.Dtos.PacienteDto;
using ClinicSistem_backend.Models;
using ClinicSistem_backend.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class pacienteController : ControllerBase
    {
        private PacienteService _pacienteService;
        public pacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        public IActionResult AdicionaPaciente([FromBody] CreatePacienteDto pacienteDto)
        {
            ReadPacienteDto readDto = _pacienteService.AdicionaPaciente(pacienteDto);
            if (readDto == null) return NoContent();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult RecuperaPacientes()
        {
            List<ReadPacienteDto> readDto = _pacienteService.RecuperaPacientes();
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPacientesPorId(int id)
        {
            ReadPacienteDto readDto = _pacienteService.RecuperaPacientesPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPaciente(int id, [FromBody] UpdatePacienteDto pacienteDto)
        {
            Result resultado = _pacienteService.AtualizaPaciente(id, pacienteDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPaciente(int id)
        {
            Result resultado = _pacienteService.DeletaPaciente(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
