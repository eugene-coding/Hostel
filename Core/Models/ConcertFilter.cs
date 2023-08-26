namespace Core.Models;

/// <summary>
/// Содержит данные для фильтрации списка концертов.
/// </summary>
public sealed class ConcertFilter
{
    private DateTime? from;

    /// <inheritdoc cref="ConcertModel.City"/>
    public string? City { get; set; }

    /// <summary>
    /// Начальная дата.
    /// </summary>
    /// <remarks>
    /// Начальная дата не может быть меньше <see cref="DateTime.Now"/>.
    /// </remarks>
    public DateTime? From
    {
        get => from;
        set => from = (value.HasValue && value < DateTime.Now) 
            ? DateTime.Now : value;
    }

    /// <summary>
    /// Конечная дата.
    /// </summary>
    public DateTime? To { get; set; }
}
