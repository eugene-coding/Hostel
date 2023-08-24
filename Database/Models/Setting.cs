using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Database.Models;

/// <summary>
/// Представляет таблицу с настройками.
/// </summary>
[Comment("Настройки.")]
internal sealed class Setting
{
    /// <summary>
    /// Название настройки.
    /// </summary>
    [Key]
    [MaxLength(32)]
    [Comment("Название настройки.")]
    public required string Key { get; set; }

    /// <summary>
    /// Значение настройки.
    /// </summary>
    [MaxLength(32)]
    [Comment("Значение настройки.")]
    public required string Value { get; set; }
}
