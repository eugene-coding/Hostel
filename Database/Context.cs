using Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Database;

/// <summary>
/// Контекст базы данных.
/// </summary>
public sealed class Context : DbContext
{
    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="options">Опции для настройки контекста.</param>
    public Context(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Таблица с концертами.
    /// </summary>
    public DbSet<Concert> Concerts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concert>().HasData(
            new Concert
            {
                Id = 1,
                City = "Волгоград",
                Location = "Белая лошадь",
                Name = "Сольный концерт",
                DateTime = DateTime.Now,
                TicketsLeft = 47,
                MinPrice = 2500,
            },

            new Concert
            {
                Id = 2,
                City = "Москва",
                Location = "Тонна",
                Name = "Лазурный рассвет",
                DateTime = new DateTime(2023, 12, 24, 19, 0, 0),
                TicketsLeft = 32,
                MinPrice = 1600,
            });
    }
}
