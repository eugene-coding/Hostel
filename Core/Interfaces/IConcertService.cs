using Core.Models;

namespace Core.Interfaces;

/// <summary>
/// Сервис для работы с информацией о концертах.
/// </summary>
public interface IConcertService
{
    /// <summary>
    /// Возвращает список предстоящих концертов, подходящих под условия <paramref name="filter"/>,
    /// на странице под номером <paramref name="page"/>.
    /// </summary>
    /// <param name="page">Номер страницы.</param>
    /// <param name="filter">Фильтр.</param>
    /// <returns>Список предстоящих концертов на странице под номером <paramref name="page"/>.</returns>
    IAsyncEnumerable<ConcertModel> GetConcertModelsAsync(int page, ConcertFilter filter);

    /// <summary>
    /// Возвращает список городов, в которых планируются концерты.
    /// </summary>
    /// <returns>Список городов, в которых планируются концерты.</returns>
    IAsyncEnumerable<string> GetCities();

    /// <summary>
    /// Подсчитывает количество предстоящих концертов.
    /// </summary>
    /// <returns>Количество предстоящих концертов.</returns>
    Task<int> GetCountAsync();

    /// <summary>
    /// Подсчитывает количество предстоящих концертов, подходящих под условия в <paramref name="filter"/>.
    /// </summary>
    /// <returns>
    /// Количество предстоящих концертов?подходящих под условия в <paramref name="filter"/>.
    /// </returns>
    Task<int> GetCountAsync(ConcertFilter filter);
}
