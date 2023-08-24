using Core.Interfaces;
using Core.Models;

using Microsoft.AspNetCore.Components;

namespace Hostel.Shared;

/// <summary>
/// 
/// </summary>
public partial class Concerts
{
    private readonly List<ConcertModel> _concerts = new();
    private int _concertCount;

    [Inject] private IConcertService Service { get; init; } = null!;
    private bool DisplayLoadMoreButton { get; set; }
    
    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        await foreach (var concert in Service.GetConcertModelsAsync())
        {
            _concerts.Add(concert);
            StateHasChanged();
        }

        _concertCount = await Service.GetCountAsync();

        DisplayLoadMoreButton = _concertCount > _concerts.Count; 
    }
}
