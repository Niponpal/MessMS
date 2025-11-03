namespace Mess_Manager.Models;

public class Inventory
{
    public int Id { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    // Relationships
   // public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
