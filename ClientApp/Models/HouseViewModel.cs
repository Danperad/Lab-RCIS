using LabsDB.Entity;

namespace ClientApp.Models;

public class HouseViewModel
{
    public IEnumerable<House> Houses { get; init; }

    public HouseViewModel()
    {
        Houses = new List<House>();
    }

    public HouseViewModel(IEnumerable<House> houses)
    {
        Houses = houses;
    }
}