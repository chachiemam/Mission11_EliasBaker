using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11_EliasBaker.Models;
using Mission11_EliasBaker.Models.ViewModels;

namespace Mission11_EliasBaker.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepo;

        public HomeController(IBookRepository temp)
        {
            _bookRepo = temp;
        }

        public IActionResult Index(int pageNum, string bookType)
        {
            int pageSize = 10;
            var blah = new BooksListViewModel
            {
                Books = _bookRepo.Books
                .Where(x => x.Category == bookType || bookType == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = bookType == null ? _bookRepo.Books.Count() : _bookRepo.Books.Where(x => x.Category == bookType).Count()
                },
                CurrentBookType = bookType
            };

            return View(blah);
            //bookData
        }
    }
}