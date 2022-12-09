namespace LabsDB.Entity;

public class Indication
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Value { get; set; }
    public DateTime TimeStamp { get; set; }
    public House House { get; set; }
    public int HouseId { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }

    public Indication()
    {
        Title = string.Empty;
        TimeStamp = DateTime.Now;
        House = new House();
        Employee = new Employee();
    }

    public Indication(string title, House house, Employee employee)
    {
        TimeStamp = DateTime.Now;
        Title = title;
        House = house;
        HouseId = house.Id;
        Employee = employee;
        EmployeeId = employee.Id;
    }
}