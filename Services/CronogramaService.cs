using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.CronogramaDto;
using ClinicSistem_backend.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Services
{
    public class CronogramaService
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public CronogramaService(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCronogramaDto AdicionaCronograma(CreateCronogramaDto cronogramaDto)
        {
            Cronograma cronograma = _mapper.Map<Cronograma>(cronogramaDto);
            _context.Cronogramas.Add(cronograma);
            _context.SaveChanges();
            return _mapper.Map<ReadCronogramaDto>(cronograma);
        }

        public List<ReadCronogramaDto> RecuperaCronogramas()
        {
            List<Cronograma> cronograma = _context.Cronogramas.ToList();
            return _mapper.Map<List<ReadCronogramaDto>>(cronograma);
        }

        public ReadCronogramaDto RecuperaCronogramasPorId(int id)
        {
            Cronograma cronograma = _context.Cronogramas.FirstOrDefault(cronograma => cronograma.Id == id);
            if (cronograma != null)
            {
                return _mapper.Map<ReadCronogramaDto>(cronograma);
            }
            return null;
        }

        public Result AtualizaCronograma(int id, UpdateCronogramaDto cronogramaDto)
        {
            Cronograma cronograma = _context.Cronogramas.FirstOrDefault(cronograma => cronograma.Id == id);
            if (cronograma == null)
            {
                return Result.Fail("Cronograma não encontrada");

            }
            _mapper.Map(cronogramaDto, cronograma);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCronograma(int id)
        {
            Cronograma cronograma = _context.Cronogramas.FirstOrDefault(cronograma => cronograma.Id == id);
            if (cronograma == null)
            {
                return Result.Fail("Cronograma não encontrada");
            }
            _context.Remove(cronograma);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
