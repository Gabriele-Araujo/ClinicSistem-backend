using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.AgendaDto;
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
    public class agendaController : ControllerBase
    {
        private AgendaService _agendaService;
        public agendaController(AgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpPost]
        public IActionResult AdicionaAgenda([FromBody] CreateAgendaDto agendaDto)
        {
            ReadAgendaDto readDto = _agendaService.AdicionaAgenda(agendaDto);
            if (readDto == null) return NoContent();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult RecuperaAgendas()
        {
            List<ReadAgendaDto> readDto = _agendaService.RecuperaAgendas();
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaAgendasPorId(int id)
        {
            ReadAgendaDto readDto = _agendaService.RecuperaAgendasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAgenda(int id, [FromBody] UpdateAgendaDto agendaDto)
        {
            Result resultado = _agendaService.AtualizaAgenda(id, agendaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAgenda(int id)
        {
            Result resultado = _agendaService.DeletaAgenda(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
