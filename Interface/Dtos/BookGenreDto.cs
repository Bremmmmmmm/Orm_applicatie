namespace Interface.Dtos;

public class BookGenreDto
{
    public int BookId { get; set; }
    public int GenreId { get; set; }
    public BookDto BookDto { get; set; }
    public GenreDto GenreDto { get; set; }
}