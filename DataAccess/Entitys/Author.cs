using System.Collections.Generic;
using Interface.Dtos;

namespace DataAccess.Entitys;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Book> Books { get; set; }
    
    public Author FromDto(AuthorDto dto)
    {
        return new Author
        {
            Id = dto.Id,
            Name = dto.Name,
            Surname = dto.Surname
        };
    }
    
    public AuthorDto ToDto()
    {
        return new AuthorDto
        {
            Id = Id,
            Name = Name,
            Surname = Surname
        };
    }
}