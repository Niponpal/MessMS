using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken);
        Task<Payment?> GetPaymentByIdAsync(int id, CancellationToken cancellationToken);
        Task<Payment> AddPaymentAsync(Payment Payment, CancellationToken cancellationToken);
        Task<Payment?> UpdatePaymentAsync(Payment Payment, CancellationToken cancellationToken);
        Task<Payment> DeletePaymentAsync(int id, CancellationToken cancellationToken);
    }
}
