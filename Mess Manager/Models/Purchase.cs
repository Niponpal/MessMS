namespace Mess_Manager.Models;

public class Purchase
{
    public int Id { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }

   // Relationships
    public int SupplierId { get; set; }
    public int ItemId { get; set; }
    public Supplier Supplier { get; set; }
    public Inventory Inventory { get; set; }
}
