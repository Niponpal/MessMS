using Mess_Manager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Manager.Repository
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffsAsync(CancellationToken cancellationToken);
        Task<Staff?> GetStaffByIdAsync(int id, CancellationToken cancellationToken);
        Task<Staff> AddStaffAsync(Staff Staff, CancellationToken cancellationToken);
        Task<Staff?> UpdateStaffAsync(Staff Staff, CancellationToken cancellationToken);
        Task<Staff> DeleteStaffAsync(int id, CancellationToken cancellationToken);

        IEnumerable<SelectListItem> Dropdown();
    }
}
