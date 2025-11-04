using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> AddPaymentAsync(Payment Payment, CancellationToken cancellationToken)
        {
            await _context.Payments.AddAsync(Payment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Payment;
        }

        public async Task<Payment> DeletePaymentAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Payments.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Payments.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Payments.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Payments.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Payment?> UpdatePaymentAsync(Payment Payment, CancellationToken cancellationToken)
        {
            var data = await _context.Payments.FindAsync(Payment.Id, cancellationToken);
            if (data != null)
            {
                data.PaymentMethod= Payment.PaymentMethod;
                data.PaymentDate= Payment.PaymentDate;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
