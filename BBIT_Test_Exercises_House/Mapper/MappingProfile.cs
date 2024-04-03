using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;

namespace BBIT_Test_Exercises_House.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Apartment, ApartmentViewModel>();
        CreateMap<Resident, ResidentViewModel>();
        CreateMap<House, HouseViewModel>();
    }
}