using System.Collections.Generic;
using Interface.Dtos;

namespace DataAccess.Entitys;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; } // Navigation property
    public ICollection<BookGenre> BookGenres { get; set; } // Navigation property
    
    public Genre() // Parameterless constructor for EF Core
    {
    }

    public Genre(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public GenreDto ToDto()
    {
        return new GenreDto
        {
            Id = Id,
            Name = Name
        };
    }
}