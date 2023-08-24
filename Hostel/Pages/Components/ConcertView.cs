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
        Day = dateTime.ToString("dd");
        Month = dateTime.ToString("MMMM");
        Time = dateTime.ToString("t");
        DayOfWeek = dateTime.ToString("dddd");
        MinPrice = minPrice.ToString("# ##0");
    }

    /// <summary>
    /// День проведения.
    /// </summary>
    public string Day { get; }

    /// <summary>
    /// Месяц проведения.
    /// </summary>
    public string Month { get; }

    /// <summary>
    /// Время проведения.
    /// </summary>
    public string Time { get; }

    /// <summary>
    /// День недели.
    /// </summary>
    public string DayOfWeek { get; }

    /// <summary>
    /// Название концерта.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Город проведения.
    /// </summary>
    public required string City { get; init; }

    /// <summary>
    /// Место проведения.
    /// </summary>
    public required string Location { get; init; }

    /// <summary>
    /// Количество оставшихся билетов.
    /// </summary>
    public ushort TicketsLeft { get; init; }

    /// <summary>
    /// Минимальная цена билета.
    /// </summary>
    public string MinPrice { get; }
}
