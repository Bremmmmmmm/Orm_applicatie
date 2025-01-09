using Interface.Dtos;

namespace Interface.Interface;

public interface IGenreContainer
{
    Task<List<GenreDto>> GetGenresByIdAsync(ICollection<int>? ids);
    Task<GenreDto> GetGenreByIdAsync(int id);
}