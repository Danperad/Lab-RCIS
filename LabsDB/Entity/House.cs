namespace LabsDB.Entity;

public class House
{
    public int Id { get; set; }
    public List<Indication> Indications { get; set; }

    public House()
    {
        Indications = new List<Indication>();
    }
}