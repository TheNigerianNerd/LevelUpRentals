using LevelUpBackend.Models;

namespace LevelUpBackend.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LevelUpRentalsDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any()) return; // DB has been seeded

            var games = new Game[]
            {
                new Game { Title = "Elden Ring", Platform = "PS5", PhysicalStock = 3, HourlyRate = 2.50m },
                new Game { Title = "Halo Infinite", Platform = "Xbox", PhysicalStock = 1, HourlyRate = 2.00m },
                new Game { Title = "Mario Kart 8", Platform = "Switch", PhysicalStock = 5, HourlyRate = 1.50m }
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}