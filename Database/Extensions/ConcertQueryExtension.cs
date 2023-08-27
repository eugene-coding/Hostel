using Core.Models;

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
    /// <param name="concerts">Последовательность концертов.</param>
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

    /// <summary>
    /// Выбирает из последовательности концерты, находящиеся на странице под номером <paramref name="page"/>.
    /// </summary>
    /// <param name="concerts">Последовательность концертов.</param>
    /// <param name="page">Номер страницы.</param>
    /// <param name="concertsPerPage">Количество концертов на странице.</param>
    /// <returns>
    /// <see cref="IQueryable{T}"/>, содержащий концерты, находящиеся на странице под номером <paramref name="page"/>.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Выбрасывается, если <paramref name="page"/> или <paramref name="concertsPerPage"/> меньше единицы.
    /// </exception>
    public static IQueryable<Concert> GetPage(this IQueryable<Concert> concerts, int page, int concertsPerPage)
    {
        if (page < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(page), page,
                "Номер страницы не может быть меньше единицы.");
        }

        if (concertsPerPage < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(concertsPerPage), concertsPerPage,
                "Количество концертов на одной странице не может быть меньше единицы.");
        }

        return concerts
            .Skip((page - 1) * concertsPerPage)
            .Take(concertsPerPage);
    }

    /// <summary>
    /// Применяет к последовательности концертов <paramref name="filter"/>.
    /// </summary>
    /// <param name="concerts">Последовательность концертов.</param>
    /// <param name="filter">Фильтр концертов.</param>
    /// <returns>
    /// <see cref="IQueryable{T}"/>, содержащий концерты, отфильтрованные с помощью <paramref name="filter"/>.
    /// </returns>
    public static IQueryable<Concert> ApplyFilter(this IQueryable<Concert> concerts, ConcertFilter filter)
    {
        if (filter.ShouldFilterByCity())
        {
            concerts = concerts.Where(concert => concert.City == filter.City);
        }

        if (filter.ShouldFilterByFrom())
        {
            concerts = concerts.Where(concert => concert.DateTime >= filter.From);
        }

        if (filter.ShouldFilterByTo())
        {
            concerts = concerts.Where(concert => concert.DateTime <= filter.To);
        }

        return concerts;
    }
}
