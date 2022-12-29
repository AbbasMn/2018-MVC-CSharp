using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC.Models;
using MVC.Dtos;

namespace MVC.App_Start
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            // MVC: Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            // MVC: Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
        }
    }
}