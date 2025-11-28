using Mess_Manager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Manager.Repository;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAllAttendancesAsync(CancellationToken cancellationToken);
    Task<Attendance?> GetAttendanceByIdAsync(int id,CancellationToken cancellationToken);
    Task<Attendance> AddAttendanceAsync(Attendance attendance,CancellationToken cancellationToken);
    Task<Attendance?> UpdateAttendanceAsync(Attendance attendance, CancellationToken cancellationToken);
    Task<Attendance> DeleteAttendanceAsync(int id, CancellationToken cancellationToken);

    IEnumerable<SelectListItem> Dropdown();
}
