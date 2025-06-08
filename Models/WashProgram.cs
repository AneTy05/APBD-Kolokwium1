using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_s28508.Models;

[Table("Program")]
public class WashProgram
{
    [Key]
    public int ProgramId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    public int DurationMinutes { get; set; }
    [Required]
    public int TemperatureCelsius { get; set; }
    
    public ICollection<AvailableProgram> AvailablePrograms { get; set; }
}