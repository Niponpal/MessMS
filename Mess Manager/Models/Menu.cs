namespace Mess_Manager.Models;

public class Menu
{
    public int Id { get; set; }
    public DateTime MenuDate { get; set; }
    public string MealType { get; set; } = string.Empty;
    public string ItemName { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
}
