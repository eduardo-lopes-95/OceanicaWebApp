using OceanicaWebApp.Models;

namespace OceanicaWebApp.Dtos;

public class ReadContractDto
{
    public int Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Description { get; set; }
    public int VesselId { get; set; }
}
