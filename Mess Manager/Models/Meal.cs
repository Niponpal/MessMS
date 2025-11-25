namespace Mess_Manager.Models;

public class Meal
{
    public int Id { get; set; }

    public DateTime MealDate { get; set; }
    public string MealType { get; set; } = string.Empty; // Breakfast, Lunch, Dinner
    public float Quantity { get; set; }

    // Relationships
    public Member Member { get; set; }
    public int MemberId { get; set; }
}
