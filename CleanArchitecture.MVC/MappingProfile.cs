using AutoMapper;
using CleanArchitecture.MVC.Services.Base;
using CleanArchitecture.MVC.Models;

namespace CleanArchitecture.MVC
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeDto, LeaveTypeVM>().ReverseMap();
        }
    }
}
