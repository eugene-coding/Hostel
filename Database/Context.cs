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
}
