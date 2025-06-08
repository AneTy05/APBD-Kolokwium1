using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_s28508.Models;

[Table("Available_program")]
public class AvailableProgram
{ 
    [Key]
    public int AvailableProgramId { get; set; }
    public int WashinMachineId { get; set; }
    public int ProgramId { get; set; }
    [Required]
    [Column(TypeName = "decimal")]
    [Precision(10, 2)]
    public double Price { get; set; }
    
    [ForeignKey(nameof(ProgramId))]
    public WashProgram WashProgram { get; set; }
    [ForeignKey(nameof(WashinMachineId))]
    public WashingMachine WashingMachine { get; set; }
}