namespace Hostel.Pages.Components;

public partial class Concerts
{
    private readonly IEnumerable<ConcertView> _concerts = new List<ConcertView>
    {
        new ConcertView(DateTime.Now, 2400)
        {
            City = "Волгоград",
            Location = "Белая Лошадь",
            Name = "Сольный концерт",
            TicketsLeft = 45,
        },

        new ConcertView(new DateTime(2022,10,12,20,00, 00), 2500)
        {
            City = "Москва",
            Location = "Тонна",
            Name = "Сольный концерт",
            TicketsLeft = 70,
        },
    };
}
