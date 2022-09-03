using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.ProcedimentoDto;
using ClinicSistem_backend.Models;
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
    public class procedimentoController : ControllerBase
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public procedimentoController(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaProcedimento([FromBody] CreateProcedimentoDto procedimentoDto)
        {
            Procedimento procedimento = _mapper.Map<Procedimento>(procedimentoDto);

            _context.Procedimentos.Add(procedimento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaProcedimentosPorId), new { Id = procedimento.Id }, procedimento);
        }

        [HttpGet]
        public IEnumerable<Procedimento> RecuperaPacientes()
        {
            return _context.Procedimentos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaProcedimentosPorId(int id)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
            if (procedimento != null)
            {
                ReadProcedimentoDto procedimentoDto = _mapper.Map<ReadProcedimentoDto>(procedimento);

                return Ok(procedimento);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaProcedimento(int id, [FromBody] UpdateProcedimentoDto procedimentoDto)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
            if (procedimento == null)
            {
                return NotFound();
            }
            _mapper.Map(procedimentoDto, procedimento);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaProcedimento(int id)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
            if (procedimento == null)
            {
                return NotFound();
            }
            _context.Remove(procedimento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
