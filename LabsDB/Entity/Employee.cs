namespace LabsDB.Entity;

public class Employee
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public Employee()
    {
        Login = string.Empty;
        Password = string.Empty;
    }

    public Employee(string login, string password)
    {
        Login = login;
        Password = password;
    }
}