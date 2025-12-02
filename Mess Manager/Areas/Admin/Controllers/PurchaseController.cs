using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers;

[Area("Admin")]

public class PurchaseController : Controller
{
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly ISupplierRepository _supplierRepository;

 

    public PurchaseController(IPurchaseRepository purchaseRepository, IInventoryRepository inventoryRepository, ISupplierRepository supplierRepository)
    {
        _purchaseRepository = purchaseRepository;
        _inventoryRepository = inventoryRepository;
        _supplierRepository = supplierRepository;
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
            ViewData["SupplierId"] = _inventoryRepository.Dropdown();
            ViewData["InventoryId"] = _inventoryRepository.Dropdown();
            return View(new Purchase());
        }
        var purchases = await _purchaseRepository.GetPurchaseByIdAsync(id, cancellationToken);
        if (purchases == null)
        {
            return NotFound();
        }
        ViewData["SupplierId"] = _inventoryRepository.Dropdown();
        ViewData["InventoryId"] = _inventoryRepository.Dropdown();
        return View(purchases);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Purchase  purchase, CancellationToken cancellationToken)
    {
        if (purchase.Id == 0)
        {
            ViewData["SupplierId"] = _inventoryRepository.Dropdown();
            ViewData["InventoryId"] = _inventoryRepository.Dropdown();
            await _purchaseRepository.AddPurchaseAsync(purchase, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ViewData["SupplierId"] = _inventoryRepository.Dropdown();
            ViewData["InventoryId"] = _inventoryRepository.Dropdown();
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
