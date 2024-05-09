using AutoMapper;
using Person.Model.DTOs;
using Person.Model.Entities;
using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Service.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreatePersonRequest, ThePerson>();
            CreateMap<UpdatePersonRequest, ThePerson>();
            CreateMap<ThePerson, PersonDTO>();
        }
    }
}
