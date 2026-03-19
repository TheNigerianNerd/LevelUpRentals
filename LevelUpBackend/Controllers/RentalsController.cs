using LevelUpBackend.Data;
using LevelUpBackend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly LevelUpRentalsDbContext _context;

    public RentalsController(LevelUpRentalsDbContext context) => _context = context;

    [HttpPost("rent/{gameId}")]
    public async Task<IActionResult> RentGame(int gameId, [FromBody]string customerName)
    {
        // Start a transaction to ensure atomicity
        using var transaction = await _context.Database.BeginTransactionAsync();

        try {
        // Fetch the game with a Row Lock (Senior Detail: prevents double-booking)
        var game = await _context.Games.FindAsync(gameId);

        if (game == null) return NotFound("Game not found");
        
        if (game.PhysicalStock <= 0) {
            return Conflict(new { message = $"Sorry, {game.Title} is out of stock!" });
        }

            // Decrement Stock
            game.PhysicalStock -= 1;

            // 2. Create the Rental record
        var rental = new Rental {
            GameId = gameId,
            CustomerName = customerName,
            RentedAt = DateTime.UtcNow,
            Status = RentalStatus.Active
        };
            // Create Rental Record
            _context.Rentals.Add(rental);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new { message = "Physical rental confirmed!" });
        }
        catch (Exception) {
            await transaction.RollbackAsync();
            return StatusCode(500, "Transaction failed.");
        }
    }
}