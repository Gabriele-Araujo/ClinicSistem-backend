using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.PacienteDto;
using ClinicSistem_backend.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Services
{
    public class PacienteService
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public PacienteService(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPacienteDto AdicionaPaciente(CreatePacienteDto pacienteDto)
        {
            Paciente paciente = _mapper.Map<Paciente>(pacienteDto);
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return _mapper.Map<ReadPacienteDto>(paciente);
        }

        public List<ReadPacienteDto> RecuperaPacientes()
        {
            List<Paciente> paciente = _context.Pacientes.ToList();
            return _mapper.Map<List<ReadPacienteDto>>(paciente);
        }

        public ReadPacienteDto RecuperaPacientesPorId(int id)
        {
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.Id == id);
            if (paciente != null)
            {
                return _mapper.Map<ReadPacienteDto>(paciente);
            }
            return null;
        }

        public Result AtualizaPaciente(int id, UpdatePacienteDto pacienteDto)
        {
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.Id == id);
            if (paciente == null)
            {
                return Result.Fail("Paciente não encontrada");

            }
            _mapper.Map(pacienteDto, paciente);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaPaciente(int id)
        {
            Paciente paciente = _context.Pacientes.FirstOrDefault(paciente => paciente.Id == id);
            if (paciente == null)
            {
                return Result.Fail("Paciente não encontrada");
            }
            _context.Remove(paciente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
