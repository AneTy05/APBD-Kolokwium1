namespace Kolokwium_s28508.DTOs;

public class CustomerPurchasesDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    
    public List<PurchaseDTO> Purchases { get; set; }
}

