using Books.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksService;

public sealed class BookService(BooksDbContext dbContext) : IBookService
{
    public async Task<IReadOnlyList<BookDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Books
            .AsNoTracking()
            .OrderBy(book => book.Id)
            .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Isbn))
            .ToListAsync(cancellationToken);
    }

    public async Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Books
            .AsNoTracking()
            .Where(book => book.Id == id)
            .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Isbn))
            .SingleOrDefaultAsync(cancellationToken);
    }
}