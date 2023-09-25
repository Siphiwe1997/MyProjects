using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyJourney.Data;
using MyJourney.Models;
using System.Data;

namespace MyJourney.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public SubjectController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var subjects = _repo.Matric.FindAll()
                .OrderBy(c => c.SubjectName).ToList();
            ViewBag.ApsScore = CalculateApsScore();
            ViewBag.AverageScore = CalculateAverageScore();
            return View(subjects);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Add", new Subject());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Update";
            var subject = _repo.Matric.GetById(id);
            return View("Edit", subject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                if (subject.SubjectId == 0)
                {
                    _repo.Matric.Create(subject);
                    TempData["Message"] = $"{subject.SubjectName} has been added";
                }
                else
                {
                    _repo.Matric.Update(subject);
                    TempData["Message"] = $"{subject.SubjectName} has been updated";
                }
                _repo.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("Edit");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Subject subject = _repo.Matric.GetById(id);
            return View(subject);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Subject subject)
        {
            _repo.Matric.Delete(subject);
            TempData["Message"] = $"{subject.SubjectName} has been deleted";
            _repo.Save();
            return RedirectToAction("Index");
        }

        public int CalculateApsScore()
        {
            var subjects = _repo.Matric.FindAll(); // Retrieve subjects from the repository
            int totalLevel = subjects.Where(s => s.SubjectName != "Life Orientation").Sum(s => s.Level);
            return totalLevel;
        }

        public double CalculateAverageScore()
        {
            var subjects = _repo.Matric.FindAll(); // Retrieve subjects from the repository

            // Calculate average score based on 'SubjectMarks'
            double totalMarks = subjects.Sum(s => s.SubjectMarks);
            int subjectCount = subjects.Count();
            double averageScore = 0.0;

            if (subjectCount > 0)
            {
                averageScore = totalMarks / subjectCount;
            }
            else
            {
                // Handle the case when there are no subjects
                averageScore = 0.0;
            }

            return Math.Round(averageScore, 2); 
        }

    }
}
