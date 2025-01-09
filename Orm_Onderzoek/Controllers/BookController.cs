using DataAccess.Entitys;
using Interface.Dtos;
using Interface.Interface;
using Microsoft.AspNetCore.Mvc;
using Orm_Onderzoek.Models;

namespace Orm_Onderzoek.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookContainer _bookContainer;
    private readonly IBookGenreContainer _bookGenreContainer;
    private readonly IAuthorContainer _authorContainer;
    private readonly IGenreContainer _genreContainer;

    public BookController(IBookContainer bookContainer, IAuthorContainer authorContainer, IGenreContainer genreContainer, IBookGenreContainer bookGenreContainer)
    {
        _bookContainer = bookContainer;
        _bookGenreContainer = bookGenreContainer;
        _authorContainer = authorContainer;
        _genreContainer = genreContainer;
    }

    [HttpGet]
    [Route("GetBooks")]
    public async Task<IActionResult> GetBooks() => Ok(await _bookContainer.GetBooksAsync());

    [HttpGet]
    [Route("GetBookById")]
    public async Task<IActionResult> GetBookById(int id) => Ok(await _bookContainer.GetBookByIdAsync(id));
    
    [HttpPost]
    [Route("AddBook")]
    public async Task<IActionResult> AddBook(string title, int authorId, ICollection<int> genreIds)
    {
        var genres = await _genreContainer.GetGenresByIdAsync(genreIds);
        var book = new BookDto()
        {
            Title = title,
            AuthorId = authorId,
            GenreIds = genreIds
        };
        var bookId = await _bookContainer.AddBookAsync(book);
        
        var bookGenres = genres.Select(genre => new BookGenreDto()
        {
            BookId = bookId,
            GenreId = genre.Id
        });
        foreach (var bookGenre in bookGenres)
        {
            await _bookGenreContainer.AddBookGenreAsync(bookGenre);
        }
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }
}