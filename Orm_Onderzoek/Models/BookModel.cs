using Interface.Dtos;

namespace Orm_Onderzoek.Models;

public class BookModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public AuthorModel Author { get; set; }
    public virtual ICollection<int> GenresId { get; set; }
    public virtual ICollection<GenreModel> Genres { get; set; }
    
    public BookDto ToDto()
    {
        return new BookDto
        {
            Id = Id,
            Title = Title,
            Author = new AuthorDto { Id = AuthorId },
            Genres = GenresId.Select(g => new GenreDto { Id = g }).ToList()
        };
    }
    
    public BookModel FromDto(BookDto bookDto)
    {
        return new BookModel
        {
            Id = bookDto.Id,
            Title = bookDto.Title,
            Author = new AuthorModel().FromDto(bookDto.Author),
            Genres = bookDto.Genres.Select(g => new GenreModel().FromDto(g)).ToList()
        };
    }
}