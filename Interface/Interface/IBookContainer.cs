using Interface.Dtos;

namespace Interface.Interface;

public interface IBookContainer
{
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task<BookDto> GetBookByIdAsync(int id);
    Task<int> AddBookAsync(BookDto book);
}