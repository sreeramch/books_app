using BooksService;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<BookDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await bookService.GetAllAsync(cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var book = await bookService.GetByIdAsync(id, cancellationToken);
        return book is null ? NotFound() : Ok(book);
    }
}