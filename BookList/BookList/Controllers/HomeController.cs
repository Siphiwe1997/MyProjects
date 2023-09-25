using BookList.Data;
using Microsoft.AspNetCore.Mvc;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public IActionResult Index()
        {
            return View(_bookRepository.GetAllBooksWithBookTypeDetails()
                .OrderBy(m=>m.Name));
        }
    }
}
