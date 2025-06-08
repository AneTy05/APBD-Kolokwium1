using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s28508.Models;

[PrimaryKey(nameof(AvailableProgramId), nameof(CustomerId))]
[Table("Purchase_History")]
public class PurchaseHistory
{
    [ForeignKey(nameof(AvailableProgramId))]
    public int AvailableProgramId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public int CustomerId { get; set; }
    [Required]
    public DateTime PurchaseDate { get; set; }
    public int? Rating { get; set; }

    public Customer Customer { get; set; } = null!;
    public AvailableProgram AvailableProgram { get; set; } = null!;

}