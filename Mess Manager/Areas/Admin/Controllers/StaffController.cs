using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers;

[Area("Admin")]

public class StaffController : Controller
{
    private readonly IStaffRepository _staffRepository;

    public StaffController(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var staff = await _staffRepository.GetAllStaffsAsync(cancellationToken);
        return View(staff);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new Staff());
        }
        var staff = await _staffRepository.GetStaffByIdAsync(id, cancellationToken);
        if (staff == null)
        {
            return NotFound();
        }
        return View(staff);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Staff  staff, CancellationToken cancellationToken)
    {
        if (staff.Id == 0)
        {
            await _staffRepository.AddStaffAsync(staff, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await _staffRepository.UpdateStaffAsync(staff, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var data = await _staffRepository.GetStaffByIdAsync(id, cancellationToken);
        if (data != null)
        {
            await _staffRepository.DeleteStaffAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var staff = await _staffRepository.GetStaffByIdAsync(id, cancellationToken);
        if (staff == null)
        {
            return NotFound();
        }
        return View(staff);
    }
}
