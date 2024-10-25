using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        
        public BookController(IBookRepository employeeRepository)
        {
            _bookRepository = employeeRepository;
        }
        public ActionResult Index()
        {
            var model = _bookRepository.GetAllBook();
            return View(model);
        }
        public ActionResult AddBook()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Book Failed";
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                int result = _bookRepository.AddBook(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    TempData["Failed"] = "Failed";
                    return RedirectToAction("AddBook", "Book");
                }
            }
            return View();
        }

        public ActionResult EditBook(int BookId)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Book Failed";
            }
            Book model = _bookRepository.GetBookById(BookId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditBook(Book model)
        {
            if (ModelState.IsValid)
            {
                int result = _bookRepository.UpdateBook(model);
                if (result > 0)
                {
                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    return RedirectToAction("Index", "Book");
                }
            }
            return View();
        }

        public ActionResult DeleteBook(int BookId)
        {
            Book model = _bookRepository.GetBookById(BookId);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteBook(Book model)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Book Failed";
            }
            _bookRepository.DeleteBook(model.BookId);
            return RedirectToAction("Index", "Book");
        }
    }
}