using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var menus = await _menuRepository.GetAllMenusAsync(cancellationToken);
            return View(menus);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                return View(new Menu());
            }
            var menus = await _menuRepository.GetMenuByIdAsync(id, cancellationToken);
            if (menus == null)
            {
                return NotFound();
            }
            return View(menus);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Menu menu, CancellationToken cancellationToken)
        {
            if (menu.Id == 0)
            {
                await _menuRepository.AddMenuAsync(menu, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _menuRepository.UpdateMenuAsync(menu, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var data = await _menuRepository.GetMenuByIdAsync(id, cancellationToken);
            if (data != null)
            {
                await _menuRepository.DeleteMenuAsync(id, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var attendance = await _menuRepository.GetMenuByIdAsync(id, cancellationToken);
            if (attendance == null)
            {
                return NotFound();
            }
            return View(attendance);
        }
    }
}
