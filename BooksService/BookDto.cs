namespace BooksService;

public sealed record BookDto(int Id, string Title, string Author, string? Isbn);