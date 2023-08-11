using OceanicaWebApp.Models;

namespace OceanicaWebApp.Dtos;

public class UpdateContractDto
{
    public int Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Description { get; set; }
}
