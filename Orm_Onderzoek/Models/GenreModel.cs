using Interface.Dtos;

namespace Orm_Onderzoek.Models;

public class GenreModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BookModel> Books { get; set; } 
    
    public GenreDto ToDto()
    {
        return new GenreDto
        {
            Id = Id,
            Name = Name,
            Books = Books.Select(b => b.ToDto()).ToList()
        };
    }
    
    public GenreModel FromDto(GenreDto genreDto)
    {
        Id = genreDto.Id;
        Name = genreDto.Name;
        Books = genreDto.Books.Select(b => new BookModel().FromDto(b)).ToList();
        return this;
    }
}