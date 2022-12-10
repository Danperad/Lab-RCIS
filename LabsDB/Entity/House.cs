namespace LabsDB.Entity;

public class House
{
    public House()
    {
        Indications = new List<Indication>();
    }

    public int Id { get; set; }
    public List<Indication> Indications { get; set; }
}