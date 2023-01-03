using AutoMapper;
using Domain.Dtos;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectDto, Project>()
                .ForMember(des=>des.ContractFileName,opt=>opt.Ignore())
                .ForMember(des => des.ContractFileType, opt => opt.Ignore())
                .ForMember(des => des.ContractFile, opt => opt.Ignore())
                .ForMember(des => des.ProjectManagerId, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
