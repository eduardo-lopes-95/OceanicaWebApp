using AutoMapper;
using OceanicaWebApp.Dtos;
using OceanicaWebApp.Models;

namespace OceanicaWebApp.Profiles;

public class ContractProfile : Profile
{
    public ContractProfile()
    {
        CreateMap<CreateContractDto, Contract>().ReverseMap();
        CreateMap<UpdateContractDto, Contract>().ReverseMap();
        CreateMap<ReadContractDto, Contract>().ReverseMap();
    }
}
