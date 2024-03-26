using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission11_EliasBaker.Infrastructure;
using Mission11_EliasBaker.Models;

namespace Mission11_EliasBaker.Pages
{
	public class CartModel : PageModel
	{
		private IBookRepository _bookRepo;

		public CartModel(IBookRepository temp)
		{
			_bookRepo = temp;
		}
		public Cart? Cart { get; set; }

		public string ReturnUrl { get; set; } = "/";
		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl ?? "/";
			Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
		}

		public IActionResult OnPost(int bookId, string returnUrl)
		{
			Book b = _bookRepo.Books
				.FirstOrDefault(x => x.BookId == bookId);

			if (b != null)
			{
				Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
				Cart.AddItem(b, 1);
				HttpContext.Session.SetJson("cart", Cart);
			}

			return RedirectToPage(new { returnUrl = returnUrl });
		}
	}
}
