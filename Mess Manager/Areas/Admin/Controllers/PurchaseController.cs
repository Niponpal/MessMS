using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var purchases = await _purchaseRepository.GetAllPurchasesAsync(cancellationToken);
            return View(purchases);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Purchase());
            }
            var purchases = await _purchaseRepository.GetPurchaseByIdAsync(id, cancellationToken);
            if (purchases == null)
            {
                return NotFound();
            }
            return View(purchases);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Purchase  purchase, CancellationToken cancellationToken)
        {
            if (purchase.Id == 0)
            {
                await _purchaseRepository.AddPurchaseAsync(purchase, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _purchaseRepository.UpdatePurchaseAsync(purchase, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _purchaseRepository.GetPurchaseByIdAsync(id, cancellationToken);
            if (data != null)
            {
                await _purchaseRepository.DeletePurchaseAsync(id, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var purchases = await _purchaseRepository.GetPurchaseByIdAsync(id, cancellationToken);
            if (purchases == null)
            {
                return NotFound();
            }
            return View(purchases);
        }
    }
}
