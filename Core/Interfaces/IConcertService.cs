using Core.Models;

namespace Core.Interfaces;

/// <summary>
/// Сервис для работы с информацией о концертах.
/// </summary>
public interface IConcertService
{
    /// <summary>
    /// Вовзаращает список предстоящих концертов.
    /// </summary>
    /// <returns>Список предстоящих концертов.</returns>
    IAsyncEnumerable<ConcertModel> GetConcertModelsAsync();

    /// <summary>
    /// Подсчитывает количество предстоящих концертов.
    /// </summary>
    /// <returns>Количество предстоящих концертов.</returns>
    Task<int> GetCountAsync();
}
