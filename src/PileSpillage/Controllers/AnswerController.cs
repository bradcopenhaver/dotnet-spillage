using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PileSpillage.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PileSpillage.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswerController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Answer answer)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            answer.Author = currentUser;
            _db.Answers.Add(answer);
            _db.SaveChanges();
            return RedirectToAction("Details", "Question", new { id = answer.QuestionId });
        }
    }
}
