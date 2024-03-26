﻿using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Mission11_EliasBaker.Models
{
	public class Cart
	{
		public List<CartLine> Lines { get; set; } = new List<CartLine>();

		public void AddItem(Book b, int quantity)
		{
			CartLine? line = Lines
				.Where(x => x.Book.BookId == b.BookId)
				.FirstOrDefault();
			if (line == null) 
			{
				Lines.Add(new CartLine
				{
					Book = b,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Book b) => Lines.RemoveAll(x => x.Book.BookId == b.BookId);

		public void Clear() => Lines.Clear();

		public double CalculateTotal() => Lines.Sum(x => x.Book.Price * x.Quantity);

		public class CartLine
		{
			public int CartLineId { get; set; }
			public Book Book { get; set; }
			public int Quantity { get; set; }
		}
	}
}
