using Core.Interfaces;

using Database.Constants;
using Database.Models;

using Microsoft.EntityFrameworkCore;

namespace Database.Services;

/// <inheritdoc cref="ISettingService"/>
public sealed class SettingService : ISettingService
{
    private readonly DbSet<Setting> _settings;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    public SettingService(Context context)
    {
        _settings = context.Settings;
    }

    /// <inheritdoc/>
    public async Task<int> GetConcertsPerPageAsync()
    {
        var result = await _settings
            .Where(setting => setting.Key == SettingKey.ConcertsPerPage)
            .Select(setting => setting.Value)
            .SingleAsync();

        return int.Parse(result);
    }
}
