using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers;

public class AttendanceController : Controller
{
    private readonly IAttendanceRepository _attendance;
    public AttendanceController(IAttendanceRepository attendance)
    {
        _attendance = attendance;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var attenandances = await _attendance.GetAllAttendancesAsync(cancellationToken);
        return View(attenandances);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if(id == 0)
        {
            return View(new Attendance());
        }
        var attendance = await _attendance.GetAttendanceByIdAsync(id, cancellationToken);
        if(attendance == null)
        {
            return NotFound();
        }
        return View(attendance);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Attendance attendance, CancellationToken cancellationToken)
    {
            if (attendance.Id == 0)
            {
                await _attendance.AddAttendanceAsync(attendance, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _attendance.UpdateAttendanceAsync(attendance, cancellationToken);
                return RedirectToAction(nameof(Index));
            }      
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var data = await _attendance.GetAttendanceByIdAsync(id, cancellationToken);
        if (data != null)
        {
            await _attendance.DeleteAttendanceAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var attendance = await _attendance.GetAttendanceByIdAsync(id, cancellationToken);
        if(attendance == null)
        {
            return NotFound();
        }
        return View(attendance);
    }
}
