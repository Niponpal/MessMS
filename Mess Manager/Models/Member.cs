namespace Mess_Manager.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime JoiningDate { get; set; }
    public bool Status { get; set; }

    //// Relationships
    public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
