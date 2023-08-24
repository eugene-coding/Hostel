using Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Database.Extensions;

/// <summary>
/// Класс расширения для запросов к таблице <see cref="Concert"/>.
/// </summary>
public static class ConcertQueryExtension
{
    /// <summary>
    /// Выбирает из последовательности предстоящие концерты.
    /// </summary>
    /// <param name="concerts">Список концертов.</param>
    /// <returns><see cref="IQueryable{T}"/>, содержащий предстоящие концерты.</returns>
    public static IQueryable<Concert> GetUpcoming(this DbSet<Concert> concerts)
    {
        return concerts.Where(concert => concert.DateTime > DateTime.Now);
    }

    /// <inheritdoc cref="GetUpcoming(DbSet{Concert})"/>
    public static IQueryable<Concert> GetUpcoming(this IQueryable<Concert> concerts)
    {
        return concerts.Where(concert => concert.DateTime > DateTime.Now);
    }
}
