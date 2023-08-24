namespace Core.Interfaces;

/// <summary>
/// Сервис для получения настроек приложения.
/// </summary>
public interface ISettingService
{
    /// <summary>
    /// Возвращает количество концертов, получаемых в рамках одной страницы. 
    /// </summary>
    /// <returns>
    /// Число, определяющее, сколько концертов нужно загрузить в рамках одной страницы.
    /// </returns>
    Task<int> GetConcertsPerPageAsync();
}
