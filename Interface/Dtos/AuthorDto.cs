namespace Interface.Dtos;

public class AuthorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<BookDto> Books { get; set; }
}