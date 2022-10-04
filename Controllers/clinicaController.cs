using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.ClinicaDto;
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
    public class clinicaController : ControllerBase
    {
        private ClinicaService _clinicaService;
        public clinicaController(ClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }

        [HttpPost]
        public IActionResult AdicionaClinica([FromBody] CreateClinicaDto clinicaDto)
        {
            ReadClinicaDto readDto = _clinicaService.AdicionaClinica(clinicaDto);
            if (readDto == null) return NoContent();
            return Ok(readDto);
        }

        [HttpGet]
        public IActionResult RecuperaClinicas()
        {
            List<ReadClinicaDto> readDto = _clinicaService.RecuperaClinicas();
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaClinicasPorId(int id)
        {
            ReadClinicaDto readDto = _clinicaService.RecuperaClinicasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaClinica(int id, [FromBody] UpdateClinicaDto clinicaDto)
        {
            Result resultado = _clinicaService.AtualizaClinica(id, clinicaDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaClinica(int id)
        {
            Result resultado = _clinicaService.DeletaClinica(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
