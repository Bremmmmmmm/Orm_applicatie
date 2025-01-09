using Interface.Dtos;

namespace Interface.Interface;

public interface IBookGenreContainer
{
    Task AddBookGenreAsync(BookGenreDto bookGenreDto);
}