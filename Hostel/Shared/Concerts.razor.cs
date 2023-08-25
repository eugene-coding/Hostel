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
    private List<string> _cities = new();

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
}
