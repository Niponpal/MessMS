using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers;

[Area("Admin")]

public class SupplierController : Controller
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierController(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var suppliers = await _supplierRepository.GetAllSuppliersAsync(cancellationToken);
        return View(suppliers);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new Supplier());
        }
        var supplier = await _supplierRepository.GetSupplierByIdAsync(id, cancellationToken);
        if (supplier == null)
        {
            return NotFound(); 
        }
        return View(supplier);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Supplier supplier , CancellationToken cancellationToken)
    {
        if (supplier.Id == 0)
        {
            await _supplierRepository.AddSupplierAsync(supplier, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await _supplierRepository.UpdateSupplierAsync(supplier, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var data = await _supplierRepository.GetSupplierByIdAsync(id, cancellationToken);
        if (data != null)
        {
            await _supplierRepository.DeleteSupplierAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.GetSupplierByIdAsync(id, cancellationToken);
        if (supplier == null)
        {
            return NotFound();
        }
        return View(supplier);
    }
}
