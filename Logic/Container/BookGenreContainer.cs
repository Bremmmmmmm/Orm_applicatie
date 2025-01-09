using DataAccess.Entitys;
using Interface.Dtos;
using Interface.Interface;

namespace Logic.Container;

public class BookGenreContainer(IRepository<BookGenre> bookGenreRepository) : IBookGenreContainer
{
    public async Task AddBookGenreAsync(BookGenreDto bookGenreDto)
    {
        BookGenre bookGenre = new BookGenre(bookGenreDto);
        await bookGenreRepository.AddAsync(bookGenre);
    }
}