using Core.Interfaces;
using Core.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;

namespace Hostel.Shared;

/// <summary>
/// Блок отображения концертов.
/// </summary>
public partial class Concerts
{
    private readonly List<ConcertModel> _concerts = new();
    private readonly List<string> _cities = new();

    private ConcertFilter _filter = null!;
    private bool _displayLoadMoreButton;
    private int _totalConcertsCount;
    private int _pageToLoad = 1;
    private string _today = string.Empty;

    [Inject] private IStringLocalizer<Concerts> Localizer { get; init; } = null!;
    [Inject] private IConcertService Service { get; init; } = null!;

    /// <inheritdoc/>
    protected override void OnInitialized()
    {
        var today = DateTime.Now.Date;

        _today = today.ToString("yyyy-MM-dd");
        _filter = new ConcertFilter(today, OnFilterChanged);
    }

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!firstRender)
        {
            return;
        }

        _totalConcertsCount = await Service.GetCountAsync();

        // Концертов нет
        if (_totalConcertsCount == 0)
        {
            return;
        }

        await foreach (var city in Service.GetCities())
        {
            _cities.Add(city);
        }

        await GetNextPageAsync();

        StateHasChanged();
    }

    private async Task GetNextPageAsync()
    {
        await foreach (var concert in Service.GetConcertModelsAsync(_pageToLoad++, _filter))
        {
            _concerts.Add(concert);
        }

        _displayLoadMoreButton = _totalConcertsCount > _concerts.Count;
    }

    private void OnCityChanged(ChangeEventArgs e)
    {
        var city = e.Value?.ToString() ?? string.Empty;
        _filter.City = city;
    }

    private void OnFromChanged(ChangeEventArgs e)
    {
        if (DateTime.TryParse(e.Value?.ToString(), out var from))
        {
            _filter.From = from;
        }
        else
        {
            _filter.ResetFrom();
        }
    }

    private void OnToChanged(ChangeEventArgs e)
    {
        if (DateTime.TryParse(e.Value?.ToString(), out var to))
        {
            _filter.To = to;
        }
        else
        {
            _filter.ResetTo();
        }
    }

    private void OnClearReset(MouseEventArgs e)
    {
        _filter.Reset();
    }

    private async Task OnFilterChanged()
    {
        ClearConcerts();

        _totalConcertsCount = await Service.GetCountAsync(_filter);

        if (_totalConcertsCount > 0)
        {
            await GetNextPageAsync();
        }

        StateHasChanged();
    }

    private void ClearConcerts()
    {
        _concerts.Clear();
        _pageToLoad = 1;
    }
}
