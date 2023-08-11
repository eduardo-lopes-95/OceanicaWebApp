using AutoMapper;
using OceanicaWebApp.Dtos;
using OceanicaWebApp.Models;

namespace OceanicaWebApp.Profiles;

public class VesselProfile : Profile
{
    public VesselProfile()
    {
        CreateMap<CreateVesselDto, Vessel>().ReverseMap();
        CreateMap<UpdateVesselDto, Vessel>().ReverseMap();
        CreateMap<ReadVesselDto, Vessel>().ReverseMap();
    }
}
