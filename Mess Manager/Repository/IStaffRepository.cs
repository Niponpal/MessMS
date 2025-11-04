using Mess_Manager.Models;

namespace Mess_Manager.Repository
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffsAsync(CancellationToken cancellationToken);
        Task<Staff?> GetStaffByIdAsync(int id, CancellationToken cancellationToken);
        Task<Staff> AddStaffAsync(Staff Staff, CancellationToken cancellationToken);
        Task<Staff?> UpdateStaffAsync(Staff Staff, CancellationToken cancellationToken);
        Task<Staff> DeleteStaffAsync(int id, CancellationToken cancellationToken);
    }
}
