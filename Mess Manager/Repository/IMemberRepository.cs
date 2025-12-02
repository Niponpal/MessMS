using Mess_Manager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Manager.Repository
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync(CancellationToken cancellationToken);
        Task<Member?> GetMemberByIdAsync(int id, CancellationToken cancellationToken);
        Task<Member> AddMemberAsync(Member Member, CancellationToken cancellationToken);
        Task<Member?> UpdateMemberAsync(Member Member, CancellationToken cancellationToken);
        Task<Member> DeleteMemberAsync(int id, CancellationToken cancellationToken);
        IEnumerable<SelectListItem> Dropdown();
      
    }
}
