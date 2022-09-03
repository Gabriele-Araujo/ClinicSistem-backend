using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.DentistaDto;
using ClinicSistem_backend.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Services
{
    public class DentistaService
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public DentistaService(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadDentistaDto AdicionaDentista(CreateDentistaDto dentistaDto)
        {
            Dentista dentista = _mapper.Map<Dentista>(dentistaDto);
            _context.Dentistas.Add(dentista);
            _context.SaveChanges();
            return _mapper.Map<ReadDentistaDto>(dentista);
        }

        public List<ReadDentistaDto> RecuperaDentistas()
        {
            List<Dentista> dentista = _context.Dentistas.ToList();
            return _mapper.Map<List<ReadDentistaDto>>(dentista);
        }

        public ReadDentistaDto RecuperaDentistasPorId(int id)
        {
            Dentista dentista = _context.Dentistas.FirstOrDefault(dentista => dentista.Id == id);
            if (dentista != null)
            {
                return _mapper.Map<ReadDentistaDto>(dentista);
            }
            return null;
        }

        public Result AtualizaDentista(int id, UpdateDentistaDto dentistaDto)
        {
            Dentista dentista = _context.Dentistas.FirstOrDefault(dentista => dentista.Id == id);
            if (dentista == null)
            {
                return Result.Fail("Dentista não encontrada");

            }
            _mapper.Map(dentistaDto, dentista);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaDentista(int id)
        {
            Dentista dentista = _context.Dentistas.FirstOrDefault(dentista => dentista.Id == id);
            if (dentista == null)
            {
                return Result.Fail("Dentista não encontrada");
            }
            _context.Remove(dentista);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
