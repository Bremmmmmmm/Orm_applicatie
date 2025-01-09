using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interface.Dtos;

namespace DataAccess.Entitys;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
    private ICollection<int> genreIds;


    public Book() // Parameterless constructor for EF Core
    {
    }

    public Book(BookDto dto)
    {
        Title = dto.Title;
        AuthorId = dto.AuthorId;
        Genres = dto.Genres?.Select(g => new Genre(g.Id, g.Name)).ToList() ?? new List<Genre>();
        genreIds = dto.GenreIds;
    }

    public BookDto ToDto()
    {
        return new BookDto
        {
            Id = Id,
            Title = Title,
            Author = Author != null ? Author.ToDto() : new AuthorDto(),
            Genres = Genres != null ? Genres.Select(g => g.ToDto()).ToList() : new List<GenreDto>()
        };
    }
}