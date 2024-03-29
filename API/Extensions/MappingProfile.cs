﻿using AutoMapper;
using Core;
using Infrastructure.DTOs.Booking;
using Infrastructure.DTOs.Contract;
using Infrastructure.DTOs.Division;
using Infrastructure.DTOs.Project;
using Infrastructure.DTOs.Property;
using Infrastructure.DTOs.SaleBatch;

namespace API.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectCreationModel>();
            CreateMap<ProjectCreationModel, Project>();

            CreateMap<Division, DivisionCreationModel>();
            CreateMap<DivisionCreationModel, Division>();

            CreateMap<Property, PropertyCreationModel>();
            CreateMap<PropertyCreationModel, Property>();

            CreateMap<SaleBatch, SaleBatchCreationModel>();
            CreateMap<SaleBatchCreationModel, SaleBatch>();

            CreateMap<Booking, BookingCreationModel>();
            CreateMap<BookingCreationModel, Booking>();

            CreateMap<Contract, ContractCreationModel>();
            CreateMap<ContractCreationModel, Contract>();
        }
    }
}
