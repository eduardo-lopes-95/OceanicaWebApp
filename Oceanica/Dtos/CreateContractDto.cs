using OceanicaWebApp.Models;

namespace OceanicaWebApp.Dtos;

public class CreateContractDto
{
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Description { get; set; }
    public int VesselId { get; set; }
}
