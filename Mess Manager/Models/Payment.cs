namespace Mess_Manager.Models;

public class Payment
{
    public int Id { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }

    // Relationships
    public Member Member { get; set; }
    public int MemberId { get; set; }
   
}
