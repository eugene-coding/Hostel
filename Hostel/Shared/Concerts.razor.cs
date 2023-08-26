using Core.Interfaces;
using Core.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Hostel.Shared;

/// <summary>
/// Блок отображения концертов.
/// </summary>
public partial class Concerts
{
    private readonly List<ConcertModel> _concerts = new();
    private readonly List<string> _cities = new();
    private readonly ConcertFilter _filter = new();
    private readonly string _minDate = DateTime.Now.ToString("yyyy-MM-dd");

    private bool _displayLoadMoreButton;
    private int _concertsCount;
    private int _pageToLoad = 1;

    [Inject] private IStringLocalizer<Concerts> Localizer { get; init; } = null!;
    [Inject] private IConcertService Service { get; init; } = null!;

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _concertsCount = await Service.GetCountAsync();

            await GetCities();
            await GetNextPageAsync();

            StateHasChanged();
        }
    }

    private async Task GetCities()
    {
        await foreach (var city in Service.GetCities())
        {
            _cities.Add(city);
        }
    }

    private async Task GetNextPageAsync()
    {
        await foreach (var concert in Service.GetConcertModelsAsync(_pageToLoad++))
        {
            _concerts.Add(concert);
        }

        _displayLoadMoreButton = _concertsCount > _concerts.Count;
    }

    private async Task GetFilteredByCity()
    {
        await foreach (var concert in Service.GetConcertModelsAsync(_filter.City, 1))
        {
            _concerts.Add(concert);
        }

        _displayLoadMoreButton = _concertsCount > _concerts.Count;
    }

    private void OnCityChanged(ChangeEventArgs e)
    {
        var city = e.Value?.ToString();

        if (_filter.City != city)
        {
            _filter.City = city;
        }
    }

    private void OnFromChanged(ChangeEventArgs e)
    {
        if (!DateTime.TryParse(e.Value?.ToString(), out var from))
        {
            return;
        }

        if (_filter.From != from)
        {
            _filter.From = from;
        }
    }

    private void OnToChanged(ChangeEventArgs e)
    {
        if (!DateTime.TryParse(e.Value?.ToString(), out var to))
        {
            return;
        }

        if (_filter.To != to)
        {
            _filter.To = to;
        }
    }
}
