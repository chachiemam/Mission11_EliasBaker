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

        public IActionResult Index(int pageNum)
        {
            int pageSize = 5;
            var blah = new BooksListViewModel
            {
                Books = _bookRepo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _bookRepo.Books.Count()
                }
            };

            return View(blah);
            //bookData
        }
    }
}