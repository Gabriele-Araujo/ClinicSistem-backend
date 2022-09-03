using AutoMapper;
using ClinicSistem_backend.Data.Dtos.CronogramaDto;
using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Profiles
{
    public class CronogramaProfile : Profile
    {
        public CronogramaProfile()
        {
            CreateMap<CreateCronogramaDto, Cronograma>();
            CreateMap<Cronograma, ReadCronogramaDto>();
            CreateMap<UpdateCronogramaDto, Cronograma>();
        }
    }

}
