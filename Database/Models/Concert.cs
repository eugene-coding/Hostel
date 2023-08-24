using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Database.Models;

/// <summary>
/// Представляет таблицу с концертами.
/// </summary>
[Comment("Концерты.")]
public sealed class Concert
{
    /// <summary>
    /// ID концерта.
    /// </summary>
    [Comment("ID концерта.")]
    public int Id { get; set; }

    /// <summary>
    /// Название концерта.
    /// </summary>
    [MaxLength(100)]
    [Comment("Название концерта.")]
    public required string Name { get; set; }

    /// <summary>
    /// Город проведения.
    /// </summary>
    [MaxLength(100)]
    [Comment("Город проведения.")]
    public required string City { get; set; }

    /// <summary>
    /// Место проведения.
    /// </summary>
    [MaxLength(100)]
    [Comment("Место проведения.")]
    public required string Location { get; set; }

    /// <summary>
    /// Время проведения.
    /// </summary>
    [Comment("Время проведения.")]
    public required DateTime DateTime { get; set; }

    /// <summary>
    /// Количество оставшихся билетов.
    /// </summary>
    [Comment("Количество оставшихся билетов.")]
    public required int TicketsLeft { get; set; }

    /// <summary>
    /// Минимальная цена билета.
    /// </summary>
    [Comment("Минимальная цена билета.")]
    public required int MinPrice { get; set; }
}
