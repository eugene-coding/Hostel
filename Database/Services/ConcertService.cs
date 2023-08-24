using Core.Interfaces;
using Core.Models;

using Database.Extensions;
using Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Database.Services;

/// <inheritdoc cref="IConcertService"/>
public sealed class ConcertService : IConcertService
{
    private readonly DbSet<Concert> _concerts;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public ConcertService(Context context)
    {
        _concerts = context.Concerts;
    }

    /// <inheritdoc/>
    public async IAsyncEnumerable<ConcertModel> GetConcertModelsAsync()
    {
        var query = _concerts.AsNoTracking()
            .GetUpcoming()
            .OrderBy(concert => concert.DateTime)
            .Select(concert => new ConcertModel(concert.DateTime, concert.MinPrice)
            {
                Name = concert.Name,
                City = concert.City,
                Location = concert.Location,
                TicketsLeft = concert.TicketsLeft,
            })
            .AsNoTracking()
            .AsAsyncEnumerable();

        await foreach (var concert in query)
        {
            yield return concert;
        }
    }

    /// <inheritdoc/>
    public async Task<int> GetCountAsync()
    {
        return await _concerts.AsNoTracking()
            .GetUpcoming()
            .CountAsync();
    }
}
