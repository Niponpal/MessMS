using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers;
[Area("Admin")]

public class PaymentController : Controller
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMemberRepository _memberRepository;
    
    public PaymentController(IPaymentRepository paymentRepository, IMemberRepository memberRepository)
    {
        _paymentRepository = paymentRepository;
        _memberRepository = memberRepository;
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
            ViewData["MemberId"] = _memberRepository.Dropdown();
            return View(new Payment());
        }
        var payments = await _paymentRepository.GetPaymentByIdAsync(id, cancellationToken);
        if (payments == null)
        {
            return NotFound();
        }
        ViewData["MemberId"] = _memberRepository.Dropdown();
        return View(payments);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Payment payment , CancellationToken cancellationToken)
    {
        if (payment.Id == 0)
        {
            ViewData["MemberId"] = _memberRepository.Dropdown();
            await _paymentRepository.AddPaymentAsync(payment, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ViewData["MemberId"] = _memberRepository.Dropdown();
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
