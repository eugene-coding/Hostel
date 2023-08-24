using Database.Models;

namespace Database.Constants;

/// <summary>
/// Содержит доступные значения для столбца <see cref="Setting.Key"/>.
/// </summary>
internal static class SettingKey
{
    /// <summary>
    /// Количество концертов на страницу.
    /// </summary>
    public const string ConcertsPerPage = "concerts-per-page";
}
