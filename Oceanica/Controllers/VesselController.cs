using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanicaWebApp.Dtos;
using OceanicaWebApp.Models;
using OceanicaWebApp.Repositories.Abstract;
using Swashbuckle.AspNetCore.Annotations;

namespace OceanicaWebApp.Controllers;
[Route("[controller]")]
[ApiController]
public class VesselController : ControllerBase
{
    private IMapper Mapper;
    private IRepository<Vessel> VesselRepository;

    public VesselController(IRepository<Vessel> vesselRepository, IMapper mapper)
    {
        VesselRepository = vesselRepository;
        Mapper = mapper;
    }

    [HttpGet("GetVessels")]
    [SwaggerResponse(200, Type = typeof(ReadVesselDto))]
    [SwaggerResponse(400, Type = typeof(ProblemDetails))]
    public IActionResult GetVessels(
        [FromQuery] int page = 0,
        [FromQuery] int qtde = 10)
    {
        var vessels = VesselRepository.GetAll(page, qtde);
        return Ok(Mapper.Map<ICollection<ReadVesselDto>>(vessels));
    }

    [HttpGet("GetVessel")]
    public IActionResult GetVesselsById(int id)
    {
        var vessel = VesselRepository.GetById(id);
        return Ok(Mapper.Map<ReadVesselDto>(vessel));
    }

    [HttpPost("AddVessel")]
    public IActionResult Post([FromBody] CreateVesselDto dto)
    {
        var vessel = Mapper.Map<Vessel>(dto);
        var vesselInserted = VesselRepository.Insert(vessel);
        return CreatedAtAction(nameof(GetVesselsById), new { vesselInserted.Id }, dto);
    }

    [HttpPut("UpdateVessel")]
    public IActionResult Put([FromBody] UpdateVesselDto dto)
    {
        var vessel = Mapper.Map<Vessel>(dto);
        var vesselInserted = VesselRepository.Update(vessel);
        return Ok(Mapper.Map<ReadVesselDto>(vesselInserted));
    }

    [HttpDelete("DeleteVessel")]
    public IActionResult Delete(int id)
    {
        VesselRepository.DeleteById(id);
        return NoContent();
    }
}
