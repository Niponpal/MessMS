using Mess_Manager.Models;
using Mess_Manager.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers;

[Area("Admin")]
public class MemberController : Controller
{
    private readonly IMemberRepository _memberRepository;

    public MemberController(IMemberRepository memberRepository) 
    {
        _memberRepository = memberRepository;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var members = await _memberRepository.GetAllMembersAsync(cancellationToken); 
        return View(members);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new Member());
        }
        var members = await _memberRepository.GetMemberByIdAsync(id, cancellationToken);
        if (members == null)
        {
            return NotFound();
        }
        return View(members);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Member member, CancellationToken cancellationToken)
    {
        if (member.Id == 0)
        {
            await _memberRepository.AddMemberAsync(member, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await _memberRepository.UpdateMemberAsync(member, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var data = await _memberRepository.GetMemberByIdAsync(id, cancellationToken);
        if (data != null)
        {
            await _memberRepository.DeleteMemberAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetMemberByIdAsync(id, cancellationToken);
        if (member == null)
        {
            return NotFound();
        }
        return View(member);
    }
}
