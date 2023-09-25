using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyJourney.Data;
using MyJourney.Models;
using System.Data;

namespace MyJourney.Controllers
{
    public class SkillController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public SkillController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var skills = _repo.Skill.FindAll()
                .OrderBy(c => c.Name).ToList();
            return View(skills);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Add", new Skill());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var skill = _repo.Skill.GetById(id);
            return View("Edit", skill);
        }

        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                if (skill.SkillId == 0)
                {
                    _repo.Skill.Create(skill);
                    TempData["Message"] = $"{skill.Name} has been added";
                }
                else
                {
                    _repo.Skill.Update(skill);
                    TempData["Message"] = $"{skill.Name} has been updated";
                }
                _repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Skill skill = _repo.Skill.GetById(id);
            return View(skill);
        }


        [HttpPost]
        public IActionResult Delete(Skill skill)
        {
            _repo.Skill.Delete(skill);
            TempData["Message"] = "Skill has been deleted";
            _repo.Save();
            return RedirectToAction("Index");
        }

    }
}
