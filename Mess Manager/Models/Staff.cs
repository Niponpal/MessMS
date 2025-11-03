namespace Mess_Manager.Models;

public class Staff
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty; // Cook, Cleaner, Helper
    public string PhoneNumber { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime JoiningDate { get; set; }

    // Relationships
    //public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
