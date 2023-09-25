using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookList.Data;
using BookList.Models;

namespace MovieList.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookRepository _bookRepository;
		public BookController(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		[HttpGet]
		public IActionResult Add()
		{
			PopulateGenreDLL();
			return View("Add",new Book());
		}
		 
		[HttpPost]
		public IActionResult Add(Book book)
		{
			if (ModelState.IsValid)
			{
				_bookRepository.AddBook(book);
				_bookRepository.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				PopulateGenreDLL();
				return View(book);
			}
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Book book = _bookRepository.GetBookById(id);
			PopulateGenreDLL(book.BookTypeId);
            return View(book);
		}

		[HttpPost]
		public IActionResult Edit(Book book)
		{
			if (ModelState.IsValid)
			{
				try
				{
					if (book.BookId == 0)
					{
						_bookRepository.AddBook(book);
					}
					else
					{
						_bookRepository.UpdateBook(book);
					}
					   _bookRepository.SaveChanges();
						return RedirectToAction("Index", "Home");
				}
				catch (DbUpdateException)
				{
					ModelState.AddModelError("", "Unable to save changes. " +
						"Try again, and if the problem persists, " +
						"see your system administrator.");
				}
			}
			PopulateGenreDLL(book.BookTypeId);
			return View(book);
		}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();
            else
            {
                return View(book);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteMovie(Book book)
        {
            if (book != null)
            {
                _bookRepository.DeleteBook(book);
                _bookRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to Delete book";
				return View(book);
            }
        }

        private void PopulateGenreDLL(object selectedBookType = null)
        {
            ViewBag.BookTypes = new SelectList(_bookRepository.GetAllBookTypes()
                .OrderBy(b => b.BookTypeName),
                "BookTypeId", "BookTypeName", selectedBookType);
        }
    }
}
