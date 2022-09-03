using AutoMapper;
using ClinicSistem_backend.Data.Dtos.ProcedimentoDto;
using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Profiles
{
    public class ProcedimentoProfile : Profile
    {
        public ProcedimentoProfile()
        {
            CreateMap<CreateProcedimentoDto, Procedimento>();
            CreateMap<Procedimento, ReadProcedimentoDto>();
            CreateMap<UpdateProcedimentoDto, Procedimento>();
        }
    }
}
