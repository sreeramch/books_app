namespace BooksService;

public interface IBookService
{
    Task<IReadOnlyList<BookDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}