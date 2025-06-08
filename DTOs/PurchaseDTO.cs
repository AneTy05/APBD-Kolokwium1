namespace Kolokwium_s28508.DTOs;

public class PurchaseDTO
{
    public DateTime Date { get; set; }
    public int? Raiting { get; set; }
    public double Price { get; set; }
    
    public WaschingMachineDTO WashingMachine { get; set; } = null!;
    public ProgramDTO Program { get; set; } = null!;
}