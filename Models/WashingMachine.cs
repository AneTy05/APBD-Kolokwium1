using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s28508.Models;
[Table("Washing_machine")]
public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    [Required]
    [Column(TypeName = "decimal")]
    [Precision(10, 2)]
    public float MaxWeight { get; set; }
    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; }
    
}