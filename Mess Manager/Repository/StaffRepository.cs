using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Staff> AddStaffAsync(Staff Staff, CancellationToken cancellationToken)
        {
            await _context.Staffs.AddAsync(Staff, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Staff;
        }

        public async Task<Staff> DeleteStaffAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Staffs.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Staffs.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffsAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Staffs.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Staff?> GetStaffByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Staffs.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Staff?> UpdateStaffAsync(Staff Staff, CancellationToken cancellationToken)
        {

            var data = await _context.Staffs.FindAsync(Staff.Id, cancellationToken);
            if (data != null)
            {
                data.Name = Staff.Name;
                data.PhoneNumber = Staff.PhoneNumber;
                data.Salary = Staff.Salary;
                data.JoiningDate = Staff.JoiningDate;
                data.Role = Staff.Role;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
