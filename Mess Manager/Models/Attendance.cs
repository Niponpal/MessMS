namespace Mess_Manager.Models;

public class Attendance
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = string.Empty; // Present/Absent

    // Relationships
    public Staff Staff { get; set; }
    public int StaffId { get; set; }

}
