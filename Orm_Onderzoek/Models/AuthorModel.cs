using Interface.Dtos;

namespace Orm_Onderzoek.Models;

public class AuthorModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<BookModel> Books { get; set; }
    
    public AuthorDto ToDto()
    {
        return new AuthorDto
        {
            Id = Id,
            Name = Name,
            Surname = Surname
        };
    }
    
    public AuthorModel FromDto(AuthorDto authorDto)
    {
        Id = authorDto.Id;
        Name = authorDto.Name;
        Surname = authorDto.Surname;
        return this;
    }
}