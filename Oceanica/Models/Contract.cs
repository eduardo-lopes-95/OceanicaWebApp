namespace OceanicaWebApp.Models;

public class Contract
{
    public int Id { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public string Description { get; set; }
    public int VesselId { get; set; }
    public virtual Vessel Vessel { get; set; }
}
