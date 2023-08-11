namespace OceanicaWebApp.Dtos;

public class UpdateVesselDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime BuildAt { get; set; }
}