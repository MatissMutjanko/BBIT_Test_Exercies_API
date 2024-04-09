using AutoMapper;
using BBIT_Test_Exercises_House.DTOs;

namespace BBIT_Test_Exercises_House.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Apartment, ApartmentDto>();
        CreateMap<Resident, ResidentDto>();
        CreateMap<House, HouseDto>();
    }
}