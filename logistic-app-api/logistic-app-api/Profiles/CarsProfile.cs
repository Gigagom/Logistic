using AutoMapper;
using logistic_app_api.Dtos;
using logistic_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logistic_app_api.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            CreateMap<Car, CarUpdateDto>();
            CreateMap<CarUpdateDto, Car>();
        }
    }
}
