using AutoMapper;
using ClinicSistem_backend.Data;
using ClinicSistem_backend.Data.Dtos.ProcedimentoDto;
using ClinicSistem_backend.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Services
{
    public class ProcedimentoService
    {
        private ClinicContext _context;
        private IMapper _mapper;
        public ProcedimentoService(ClinicContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadProcedimentoDto AdicionaProcedimento(CreateProcedimentoDto procedimentoDto)
        {
            Procedimento procedimento = _mapper.Map<Procedimento>(procedimentoDto);
            _context.Procedimentos.Add(procedimento);
            _context.SaveChanges();
            return _mapper.Map<ReadProcedimentoDto>(procedimento);
        }

        public List<ReadProcedimentoDto> RecuperaProcedimentos()
        {
            List<Procedimento> procedimento = _context.Procedimentos.ToList();
            return _mapper.Map<List<ReadProcedimentoDto>>(procedimento);
        }

        public ReadProcedimentoDto RecuperaProcedimentosPorId(int id)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
            if (procedimento != null)
            {
                return _mapper.Map<ReadProcedimentoDto>(procedimento);
            }
            return null;
        }

        public Result AtualizaProcedimento(int id, UpdateProcedimentoDto procedimentoDto)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
            if (procedimento == null)
            {
                return Result.Fail("Procedimento não encontrada");

            }
            _mapper.Map(procedimentoDto, procedimento);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaProcedimento(int id)
        {
            Procedimento procedimento = _context.Procedimentos.FirstOrDefault(procedimento => procedimento.Id == id);
            if (procedimento == null)
            {
                return Result.Fail("Procedimento não encontrada");
            }
            _context.Remove(procedimento);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
