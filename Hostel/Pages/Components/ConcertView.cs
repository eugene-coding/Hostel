using Database.Models;

namespace Hostel.Pages.Components;

/// <summary>
/// Представление концерта.
/// </summary>
public class ConcertView
{
    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="dateTime">Дата и время проведения концерта.</param>
    /// <param name="minPrice">Минимальная цена билета.</param>
    public ConcertView(DateTime dateTime, int minPrice)
    {
        Month = dateTime.ToString("MMMM");
        DayOfWeek = dateTime.ToString("dddd");
        Day = dateTime.ToString("dd");
        Time = dateTime.ToString("t");

        MinPrice = minPrice.ToString("# ##0");
    }

    /// <inheritdoc cref="Concert.Name"/>
    public required string Name { get; init; }

    /// <inheritdoc cref="Concert.City"/>
    public required string City { get; init; }

    /// <inheritdoc cref="Concert.Location"/>
    public required string Location { get; init; }

    /// <summary>
    /// Месяц проведения.
    /// </summary>
    public string Month { get; }

    /// <summary>
    /// День недели.
    /// </summary>
    public string DayOfWeek { get; }

    /// <summary>
    /// День проведения.
    /// </summary>
    public string Day { get; }

    /// <summary>
    /// Время проведения.
    /// </summary>
    public string Time { get; }

    /// <inheritdoc cref="Concert.TicketsLeft"/>
    public required int TicketsLeft { get; init; }

    /// <inheritdoc cref="Concert.MinPrice"/>
    public string MinPrice { get; }
}
