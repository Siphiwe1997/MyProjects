using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyJourney.Data;
using MyJourney.Data.DataAccess;
using MyJourney.Models;
using MyJourney.Models.ViewModels;
using System.Data;
using System.Linq.Expressions;

namespace MyJourney.Controllers
{
	public class ModuleController : Controller
	{

		private readonly IRepositoryWrapper _repo;
		public ModuleController(IRepositoryWrapper repo)
		{
			_repo = repo;
		}
        public int iPageSize = 10;

        public IActionResult DisplayAll(string sortBy = "ModuleName", string searchString = "",
            int page = 1)
        {
            IEnumerable<Module> modules;
            Expression<Func<Module, Object>> orderBy;
            string orderByDirection;
            int iTotalModules;

            ViewData["NameSortParam"] = sortBy == "ModuleName" ? "ModuleName_desc" : "ModuleName";
            ViewData["CodeSortParam"] = sortBy == "ModuleCode" ? "ModuleCode_desc" : "ModuleCode";
            ViewData["CurrentFilter"] = searchString;

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "ModuleName";
            }

            if (sortBy.EndsWith("_desc"))
            {
                sortBy = sortBy.Substring(0, sortBy.Length - 5);
                orderByDirection = "desc";
            }
            else
            {
                orderByDirection = "asc";
            }

            orderBy = p => EF.Property<object>(p, sortBy);  //e.g. p => p.ModuleName
            if (searchString == "")
            {
                iTotalModules = _repo.Module.FindAll().Count();
                modules = _repo.Module.GetWithOptions(new QueryOptions<Module>
                {
                    OrderBy = orderBy,
                    OrderByDirection = orderByDirection,
                    Where = s => s.ModuleName.Contains(searchString) || s.ModuleCode.Contains(searchString),
                    PageNumber = page,
                    PageSize = iPageSize

                });
            }
            else
            {
                iTotalModules = _repo.Module.FindByCondition(s => s.ModuleName.ToLower().Contains(searchString.ToLower()) ||
                s.ModuleCode.ToLower().Contains(searchString.ToLower())).Count();
                modules = _repo.Module.GetWithOptions(new QueryOptions<Module>
                {
                    OrderBy = orderBy,
                    OrderByDirection = orderByDirection,
                    Where = s => s.ModuleName.ToLower().Contains(searchString.ToLower()) || 
                    s.ModuleCode.ToLower().Contains(searchString.ToLower()),
                    PageNumber = page,
                    PageSize = iPageSize
                });
            }
            ViewBag.TotalCredits = TotalCredits();
            ViewBag.GPAScore = GPAScore();
            return View(new ModuleListViewModel
            {
                Modules = modules,
                PagingInfo = new PagingInfoViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = iPageSize,
                    TotalItems = iTotalModules
                }
            });

        }
        public IActionResult Index(int _FYear = 2020)
        {
            IEnumerable<Module> modules;
            if (ModelState.IsValid)
            {
                modules = _repo.Module.FindAll()
                            .Where(y => y.Year == _FYear) // Filter modules by year
                            .OrderBy(m => m.ModuleCode)
                            .ToList();
                ViewBag.Credits = CalculateCredits();
                ViewBag.Average = CalculateAverage();
            }
            else
                return RedirectToAction("Error"); 
         
            return View(modules);
        }

        public IActionResult Error()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add";
			return View("Add", new Module());
		}
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Module module)
        {
            module.PassDescription = module.PassDescriptionM();
            _repo.Module.Create(module);
            TempData["Message"] = $"{module.ModuleName} has been added";
            _repo.Save();

            // Redirect to the "Index" action of the "Module" controller with the _FYear parameter
            return RedirectToAction("Index", "Module", new { _FYear = module.Year });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Update";
			var module = _repo.Module.GetById(id);
			return View("Edit", module);
		}
        [Authorize(Roles = "Admin")]
        [HttpPost]
		public IActionResult Edit(Module module)
		{
			if (ModelState.IsValid)
			{
				if (module.ModuleId == 0)
				{
                    module.PassDescription = module.PassDescriptionM();
                    _repo.Module.Create(module);
					TempData["Message"] = $"{module.ModuleName} has been added";
				}
				else
				{
                    module.PassDescription = module.PassDescriptionM();
                    _repo.Module.Update(module);
					TempData["Message"] = $"{module.ModuleName} has been updated";
				}
				_repo.Save();
                return RedirectToAction("Index", "Module", new { _FYear = module.Year });
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
			Module module = _repo.Module.GetById(id);
			return View(module);
		}

        [Authorize(Roles = "Admin")]
        [HttpPost]
		public IActionResult Delete(Module module)
		{
            _repo.Module.Delete(module);
            TempData["Message"] = "Module has been deleted";
            _repo.Save();
            return RedirectToAction("Index");
        }
        public int CalculateCredits()
        {
            var queryStringYear = HttpContext.Request.Query["_FYear"];
            int _FYear = 2020; // Default value

            if (!string.IsNullOrEmpty(queryStringYear) && int.TryParse(queryStringYear, out int yearFromUrl))
            {
                _FYear = yearFromUrl;
            }

            var credits = _repo.Module.FindAll()
                            .Where(m => m.Year == _FYear && m.ModuleMarks > 49)
                            .ToList();

            int totalCredits = credits.Sum(s => s.Credits);
            return totalCredits;
        }

        public double CalculateAverage()
		{
            var queryStringYear = HttpContext.Request.Query["_FYear"];
            int _FYear = 2020; // Default value

            if (!string.IsNullOrEmpty(queryStringYear) && int.TryParse(queryStringYear, out int yearFromUrl))
            {
                _FYear = yearFromUrl;
            }

            var modules = _repo.Module.FindAll().
				Where(m=>m.Year == _FYear && m.PassDescription != "Not Applicable").ToList(); // Retrieve modules from the repository

			// Calculate average score based on 'SubjectMarks'
			double totalMarks = modules.Sum(s => s.ModuleMarks);
			int moduleCount = modules.Count();
			double averageScore = 0.0;

			if (moduleCount > 0)
			{
				averageScore = totalMarks / moduleCount;
			}
			else
			{
				// Handle the case when there are no subjects
				averageScore = 0.0;
			}

			return Math.Round(averageScore, 2);
		}
        public int TotalCredits()
        {
            var credits = _repo.Module.FindAll()
                            .Where(m => m.ModuleMarks > 49)
                            .ToList();
            int totalCredits = credits.Sum(s => s.Credits );
            return totalCredits;
        }

        public double GPAScore()
        {
            var modules = _repo.Module.FindAll().Where(m=>m.PassDescription != "Not Applicable").ToList();
            double gpa;
            double ProductSumOfCreditAndMarks = 0.0;
            int totalCredits = modules.Sum(c => c.Credits);
            foreach (var module in modules)
            {
               ProductSumOfCreditAndMarks += module.Credits*module.ModuleMarks;
            }
            gpa = ProductSumOfCreditAndMarks/totalCredits;
            return Math.Round(gpa,2);
        }

	}
}
