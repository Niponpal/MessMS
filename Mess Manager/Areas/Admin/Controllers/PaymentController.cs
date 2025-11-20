using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;
        
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetAllPaymentsAsync(cancellationToken);
            return View(payments);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Payment());
            }
            var payments = await _paymentRepository.GetPaymentByIdAsync(id, cancellationToken);
            if (payments == null)
            {
                return NotFound();
            }
            return View(payments);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Payment payment , CancellationToken cancellationToken)
        {
            if (payment.Id == 0)
            {
                await _paymentRepository.AddPaymentAsync(payment, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _paymentRepository.UpdatePaymentAsync(payment, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _paymentRepository.GetPaymentByIdAsync(id, cancellationToken);
            if (data != null)
            {
                await _paymentRepository.DeletePaymentAsync(id, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetPaymentByIdAsync(id, cancellationToken);
            if (payments == null)
            {
                return NotFound();
            }
            return View(payments);
        }
    }
}
