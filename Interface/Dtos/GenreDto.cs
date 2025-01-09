namespace Interface.Dtos;

public class GenreDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BookDto> Books { get; set; } // Navigation property
}