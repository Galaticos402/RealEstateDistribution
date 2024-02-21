using AutoMapper;
using Core;
using Infrastructure.DTOs.Division;
using Infrastructure.DTOs.Project;

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
        }
    }
}
