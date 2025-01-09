namespace Interface.Dtos;

public class BookDto
{

    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public AuthorDto Author { get; set; }
    public ICollection<GenreDto> Genres { get; set; }
    public ICollection<int> GenreIds { get; set; }
    
}