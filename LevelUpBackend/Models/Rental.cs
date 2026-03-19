using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevelUpBackend.Models;
public class Rental
{
   [Key]
   public int Id{get;set;}
   [Required]
    public int GameId { get; set; }
    [ForeignKey("GameId")]
    public Game? Game { get; set; }
    
    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    public DateTime RentedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ReturnedAt { get; set; }

    // Default to Active for new rentals
    public RentalStatus Status { get; set; } = RentalStatus.Active;    
}
public enum RentalStatus
{
    Active,
    Returned,
    Lost,
    Damaged
}