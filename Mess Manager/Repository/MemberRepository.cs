using Mess_Manager.Data;
using Mess_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Mess_Manager.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Member> AddMemberAsync(Member Member, CancellationToken cancellationToken)
        {
            await _context.Members.AddAsync(Member, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Member;
        }

        public async Task<Member> DeleteMemberAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Members.FindAsync(id, cancellationToken);
            if (data != null)
            {
                _context.Members.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return null!;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync(CancellationToken cancellationToken)
        {
            var data = await _context.Members.ToListAsync(cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Member?> GetMemberByIdAsync(int id, CancellationToken cancellationToken)
        {
            var data = await _context.Members.FindAsync(id, cancellationToken);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Member?> UpdateMemberAsync(Member Member, CancellationToken cancellationToken)
        {
            var data = await _context.Members.FindAsync(Member.Id, cancellationToken);
            if (data != null)
            {
                data.Name = Member.Name;
                data.Email = Member.Email;
                data.PhoneNumber = Member.PhoneNumber;
                data.Address = Member.Address;
                data.JoiningDate = Member.JoiningDate;
                data.Status = Member.Status;
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null;
        }
    }
}
