namespace Core.Models;

/// <summary>
/// Модель для информации о коцерте.
/// </summary>
public class ConcertModel
{
    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="dateTime">Дата и время проведения концерта.</param>
    /// <param name="minPrice">Минимальная цена билета.</param>
    public ConcertModel(DateTime dateTime, int minPrice)
    {
        Month = dateTime.ToString("MMMM");
        DayOfWeek = dateTime.ToString("dddd");
        Day = dateTime.ToString("dd");
        Time = dateTime.ToString("t");
        MinPrice = minPrice.ToString("# ##0");
    }

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

    /// <summary>
    /// Количество оставшихся билетов.
    /// </summary>
    public required int TicketsLeft { get; init; }

    /// <summary>
    /// Минимальная цена билета.
    /// </summary>
    public string MinPrice { get; }
}
