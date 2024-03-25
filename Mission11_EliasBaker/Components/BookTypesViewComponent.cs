using Microsoft.AspNetCore.Mvc;
using Mission11_EliasBaker.Models;

namespace Mission11_EliasBaker.Components
{
    public class BookTypesViewComponent : ViewComponent
    {
        private IBookRepository _bookRepository;
        public BookTypesViewComponent(IBookRepository temp)
        {
            _bookRepository = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedBookType = RouteData?.Values["bookType"];

            var bookTypes = _bookRepository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(bookTypes);
        }
    }
}
