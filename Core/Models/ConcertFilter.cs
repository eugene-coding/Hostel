namespace Core.Models;

/// <summary>
/// Содержит данные для фильтрации списка концертов.
/// </summary>
public sealed class ConcertFilter
{
    private readonly DateTime _defaultFrom;

    private string _city = string.Empty;
    private DateTime? _from;
    private DateTime? _to;

    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="today">
    /// <para>
    /// Сегодняшняя дата.
    /// </para>
    /// <para>
    /// Дата необходима для того, чтобы не осуществлять фильтрацию по <see cref="From"/>,
    /// когда значение <see cref="From"/> равно <paramref name="today"/>.
    /// Так как для отображения загружаются только предстоящие концерты,
    /// дата которых больше или равна <see cref="DateTime.Now"/>,
    /// дополнительная фильтрация не нужна.
    /// </para>
    /// </param>
    /// <param name="eventHandler">
    /// Метод, который должен вызываться при изменении значений <see cref="ConcertFilter"/>.
    /// </param>
    public ConcertFilter(DateTime today, Func<Task> eventHandler)
    {
        _defaultFrom = today;

        FilterChanged += eventHandler;
    }

    /// <summary>
    /// Город проведения.
    /// </summary>
    /// <remarks>
    /// Если значение <see cref="City"/> изменяется на любое другое значение,
    /// отличное от того, что уже содержится в <see cref="City"/>,
    /// срабатывает событие <see cref="FilterChanged"/>.
    /// </remarks>
    public string City
    {
        get => _city;
        set
        {
            if (_city != value)
            {
                _city = value;
                FilterChanged?.Invoke();
            }
        }
    }

    /// <summary>
    /// Начальная дата.
    /// </summary>
    /// <remarks>
    /// <para>
    /// При установке значения <see cref="From"/> передаваемая дата урезается до значения <see cref="DateTime.Now"/>
    /// в момент создания экземпляра <see cref="ConcertFilter"/> и сохраняется <see cref="DateTime.Date"/>.
    /// </para>
    /// <para>
    /// Если значение <see cref="From"/> изменяется на любое другое значение,
    /// отличное от того, что уже содержится в <see cref="From"/>,
    /// срабатывает событие <see cref="FilterChanged"/>.
    /// </para>
    /// </remarks>
    public DateTime? From
    {
        get => _from;
        set
        {
            var date = value?.Date;

            if (_from != date)
            {
                _from = date;
                FilterChanged?.Invoke();
            }
        }
    }

    /// <summary>
    /// Конечная дата.
    /// </summary>
    /// <remarks>
    /// <para>
    /// При установке значения <see cref="To"/> передаваемая дата урезается до значения <see cref="DateTime.Now"/>
    /// в момент создания экземпляра <see cref="ConcertFilter"/> и сохраняется <see cref="DateTime.Date"/>.
    /// </para>
    /// <para>
    /// Конечная дата может быть меньше <see cref="DateTime.Now"/> лишь в том случае,
    /// если значение <see cref="To"/> не изменяли после создания экземпляра <see cref="ConcertFilter"/>,
    /// поскольку <see cref="To"/> не инициализирована изначально,
    /// или если был выполнен сброс фильтра с помощью <see cref="Reset"/>.
    /// </para>
    /// <para>
    /// Если значение <see cref="To"/> изменяется на любое другое значение,
    /// отличное от того, что уже содержится в <see cref="To"/>,
    /// срабатывает событие <see cref="FilterChanged"/>.
    /// </para>
    /// </remarks>
    public DateTime? To
    {
        get => _to;
        set
        {
            // Добавляем день, чтобы сортировка осуществлялась включительно.
            var date = value?.Date.AddDays(1);

            if (_to != date)
            {
                _to = date;
                FilterChanged?.Invoke();
            }
        }
    }

    /// <summary>
    /// Событие срабатывает, 
    /// когда значение любого из свойств для фильтрации изменяется на другое.
    /// </summary>
    public event Func<Task>? FilterChanged;

    /// <summary>
    /// Определяет, нужно ли фильтровать по <see cref="City"/>.
    /// </summary>
    /// <returns>
    /// <see langword="true"/>, если фильтровать по <see cref="City"/> нужно,
    /// иначе - <see langword="false"/>.
    /// </returns>
    public bool ShouldFilterByCity()
    {
        return City != string.Empty;
    }

    /// <summary>
    /// Определяет, нужно ли фильтровать по <see cref="From"/>.
    /// </summary>
    /// <returns>
    /// <see langword="true"/>, если фильтровать по <see cref="From"/> нужно,
    /// иначе - <see langword="false"/>.
    /// </returns>
    public bool ShouldFilterByFrom()
    {
        return From is not null && From != _defaultFrom;
    }

    /// <summary>
    /// Определяет, нужно ли фильтровать по <see cref="To"/>.
    /// </summary>
    /// <returns>
    /// <see langword="true"/>, если фильтровать по <see cref="To"/> нужно,
    /// иначе - <see langword="false"/>.
    /// </returns>
    public bool ShouldFilterByTo()
    {
        return To is not null && To >= _defaultFrom;
    }

    /// <summary>
    /// Сбрасывает значения фильтра.
    /// </summary>
    public void Reset()
    {
        _city = string.Empty;
        _from = default;
        _to = default;

        FilterChanged?.Invoke();
    }

    /// <summary>
    /// Определяет, пустой ли фильтр: равны ли все значения <see langword="null"/>.
    /// </summary>
    /// <returns>
    /// <see langword="true"/>, если фильтр пустой, иначе - <see langword="false"/>.
    /// </returns>
    public bool IsEmpty()
    {
        return !ShouldFilterByCity()
            && !ShouldFilterByFrom()
            && !ShouldFilterByTo();
    }
}
