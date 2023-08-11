using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanicaWebApp.Dtos;
using OceanicaWebApp.Models;
using OceanicaWebApp.Repositories.Abstract;
using Swashbuckle.AspNetCore.Annotations;

namespace OceanicaWebApp.Controllers;
[Route("[controller]")]
[ApiController]
public class ContractController : ControllerBase
{
    private IMapper Mapper;
    private IRepository<Contract> ContractRepository;

    public ContractController(IRepository<Contract> vesselRepository, IMapper mapper)
    {
        ContractRepository = vesselRepository;
        Mapper = mapper;
    }

    [HttpGet("GetContracts")]
    [SwaggerResponse(200, Type = typeof(ReadContractDto))]
    [SwaggerResponse(400, Type = typeof(ProblemDetails))]
    public IActionResult GetContracts(
        [FromQuery] int page = 0,
        [FromQuery] int qtde = 10)
    {
        var vessels = ContractRepository.GetAll(page, qtde);
        return Ok(Mapper.Map<ICollection<ReadContractDto>>(vessels));
    }

    [HttpGet("GetContract")]
    public IActionResult GetContractsById(int id)
    {
        var vessel = ContractRepository.GetById(id);
        return Ok(Mapper.Map<ReadContractDto>(vessel));
    }

    [HttpPost("AddContract")]
    public IActionResult Post([FromBody] CreateContractDto dto)
    {
        var vessel = Mapper.Map<Contract>(dto);
        var vesselInserted = ContractRepository.Insert(vessel);
        return CreatedAtAction(nameof(GetContractsById), new { vesselInserted.Id }, dto);
    }

    [HttpPut("UpdateContract")]
    public IActionResult Put([FromBody] UpdateContractDto dto)
    {
        var vessel = Mapper.Map<Contract>(dto);
        var vesselInserted = ContractRepository.Update(vessel);
        return Ok(Mapper.Map<ReadContractDto>(vesselInserted));
    }

    [HttpDelete("DeleteContract")]
    public IActionResult Delete(int id)
    {
        ContractRepository.DeleteById(id);
        return NoContent();
    }
}
