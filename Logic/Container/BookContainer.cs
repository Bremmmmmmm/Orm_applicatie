using DataAccess;
using DataAccess.Entitys;
using Interface.Dtos;
using Interface.Interface;
using Microsoft.EntityFrameworkCore;

namespace Logic.Container;

public class BookContainer(IRepository<Book> bookRepository) : IBookContainer
{
    public async Task<IEnumerable<BookDto>> GetBooksAsync()
    {
        var books = await bookRepository.GetAllAsync(b => b.Author, b => b.Genres);
        return books.Select(book => book.ToDto());
    } 

    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await bookRepository.GetByIdAsync(id, b => b.Author);
        return book.ToDto();
    }

    public async Task<int> AddBookAsync(BookDto bookDto)
    {
        Book book = new Book(bookDto);
        return await bookRepository.AddAsync(book);
    }
}