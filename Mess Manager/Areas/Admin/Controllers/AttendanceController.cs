using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Manager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _attendance;
        private readonly IStaffRepository _staffRepository;

        public AttendanceController(IAttendanceRepository attendance, IStaffRepository staffRepository)
        {
            _attendance = attendance;
            _staffRepository = staffRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
           
            var attendances = await _attendance.GetAllAttendancesAsync(cancellationToken);
            return View(attendances);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                ViewData["StaffId"] = _staffRepository.Dropdown();
                return View(new Attendance());
            }
            var attendance = await _attendance.GetAttendanceByIdAsync(id, cancellationToken);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = _staffRepository.Dropdown();
            return View(attendance);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Attendance attendance, CancellationToken cancellationToken)
        {
            if (attendance.Id == 0)
            {
                 ViewData["StaffId"] = _staffRepository.Dropdown();
                await _attendance.AddAttendanceAsync(attendance, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["StaffId"] = _staffRepository.Dropdown();
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
            if (attendance == null)
                return NotFound();

            return View(attendance);
        }
    }
}
