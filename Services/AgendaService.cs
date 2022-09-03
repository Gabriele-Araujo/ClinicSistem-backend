using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.AgendaDto;
using ClinicSistem_backend.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Services
{
    public class AgendaService
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public AgendaService(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAgendaDto AdicionaAgenda(CreateAgendaDto agendaDto)
        {
            Agenda agenda = _mapper.Map<Agenda>(agendaDto);
            _context.Agendas.Add(agenda);
            _context.SaveChanges();
            return _mapper.Map<ReadAgendaDto>(agenda);
        }

        public List<ReadAgendaDto> RecuperaAgendas()
        {
            List<Agenda> agenda = _context.Agendas.ToList();
            return _mapper.Map<List<ReadAgendaDto>>(agenda);
        }

        public ReadAgendaDto RecuperaAgendasPorId(int id)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
            if (agenda != null)
            {
                return _mapper.Map<ReadAgendaDto>(agenda);
            }
            return null;
        }

        public Result AtualizaAgenda(int id, UpdateAgendaDto agendaDto)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
            if (agenda == null)
            {
                return Result.Fail("Agenda não encontrada");

            }
            _mapper.Map(agendaDto, agenda);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaAgenda(int id)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.Id == id);
            if (agenda == null)
            {
                return Result.Fail("Agenda não encontrada");
            }
            _context.Remove(agenda);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
