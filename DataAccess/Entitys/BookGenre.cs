using System.ComponentModel.DataAnnotations.Schema;
using Interface.Dtos;

namespace DataAccess.Entitys;

public class BookGenre
{
    public int BookId { get; set; }
    public int GenreId { get; set; }
    public Book Book { get; set; }
    public Genre Genre { get; set; }
    
    public BookGenre()
    {
        
    }
    
    public BookGenre(BookGenreDto bookGenreDto)
    {
        BookId = bookGenreDto.BookId;
        GenreId = bookGenreDto.GenreId;
    }
}

