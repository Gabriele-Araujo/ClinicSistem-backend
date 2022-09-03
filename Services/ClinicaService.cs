using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.ClinicaDto;
using ClinicSistem_backend.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Services
{
    public class ClinicaService
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public ClinicaService(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadClinicaDto AdicionaClinica(CreateClinicaDto clinicaDto)
        {
            Clinica clinica = _mapper.Map<Clinica>(clinicaDto);
            _context.Clinicas.Add(clinica);
            _context.SaveChanges();
            return _mapper.Map<ReadClinicaDto>(clinica);
        }

        public List<ReadClinicaDto> RecuperaClinicas()
        {
            List<Clinica> clinica = _context.Clinicas.ToList();
            return _mapper.Map<List<ReadClinicaDto>>(clinica);
        }

        public ReadClinicaDto RecuperaClinicasPorId(int id)
        {
            Clinica clinica = _context.Clinicas.FirstOrDefault(clinica => clinica.Id == id);
            if (clinica != null)
            {
                return _mapper.Map<ReadClinicaDto>(clinica);
            }
            return null;
        }

        public Result AtualizaClinica(int id, UpdateClinicaDto clinicaDto)
        {
            Clinica clinica = _context.Clinicas.FirstOrDefault(clinica => clinica.Id == id);
            if (clinica == null)
            {
                return Result.Fail("Clinica não encontrada");

            }
            _mapper.Map(clinicaDto, clinica);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaClinica(int id)
        {
            Clinica clinica = _context.Clinicas.FirstOrDefault(clinica => clinica.Id == id);
            if (clinica == null)
            {
                return Result.Fail("Clinica não encontrada");
            }
            _context.Remove(clinica);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
