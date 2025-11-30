namespace Mess_Manager.Models;

public class Attendance
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = string.Empty;

    // FK
    public int StaffId { get; set; }
    public Staff Staff { get; set; }

}
