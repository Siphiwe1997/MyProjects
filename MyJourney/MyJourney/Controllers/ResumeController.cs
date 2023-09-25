using Microsoft.AspNetCore.Mvc;
using MyJourney.Data;
using MyJourney.Models;

namespace MyJourney.Controllers
{
	public class ResumeController : Controller
	{
        private readonly IRepositoryWrapper _repo;
        public ResumeController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
		{
            IEnumerable<Skill> skills = _repo.Skill.FindAll().ToList();
			return View(skills);
		}
	}
}
