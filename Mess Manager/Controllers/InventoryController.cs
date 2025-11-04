using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var inventories = await _inventoryRepository.GetAllInventorysAsync(cancellationToken);
            return View(inventories);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Inventory());
            }
            var inventories = await _inventoryRepository.GetInventoryByIdAsync(id, cancellationToken);
            if (inventories == null)
            {
                return NotFound();
            }
            return View(inventories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Inventory  inventory, CancellationToken cancellationToken)
        {
            if (inventory.Id == 0)
            {
                await _inventoryRepository.AddInventoryAsync(inventory, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _inventoryRepository.UpdateInventoryAsync(inventory, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _inventoryRepository.GetInventoryByIdAsync(id, cancellationToken);
            if (data != null)
            {
                await _inventoryRepository.DeleteInventoryAsync(id, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(id, cancellationToken);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }
    }
}
