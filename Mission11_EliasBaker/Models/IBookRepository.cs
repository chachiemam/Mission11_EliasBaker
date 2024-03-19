namespace Mission11_EliasBaker.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
