using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Attendance> AddAttendanceAsync(Attendance attendance, CancellationToken cancellationToken)
        {
            await _context.Attendances.AddAsync(attendance,cancellationToken);
            await  _context.SaveChangesAsync(cancellationToken);
            return attendance;
        }

        public async Task<Attendance> DeleteAttendanceAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Attendances.FindAsync(id,cancellationToken);
            if (data != null)
            {
                _context.Attendances.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync(CancellationToken cancellationToken)
        {
           var data = await _context.Attendances.ToListAsync(cancellationToken);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Attendances.FindAsync(id, cancellationToken);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Attendance?> UpdateAttendanceAsync(Attendance attendance, CancellationToken cancellationToken)
        {
           var data = await _context.Attendances.FindAsync(attendance.Id,cancellationToken);
            if(data != null)
            {
                data.StaffId = attendance.StaffId;
                data.Date = attendance.Date;
                data.Status = attendance.Status;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
