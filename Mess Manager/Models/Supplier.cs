namespace Mess_Manager.Models;

public class Supplier
{
    public int Id { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // Relationships
   // public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
