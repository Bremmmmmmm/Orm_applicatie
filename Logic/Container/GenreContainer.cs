using DataAccess.Entitys;
using Interface.Dtos;
using Interface.Interface;

namespace Logic.Container;

public class GenreContainer(IRepository<Genre> genreRepository) : IGenreContainer
{
    public async Task<List<GenreDto>> GetGenresByIdAsync(ICollection<int>? ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return new List<GenreDto>();
        }

        // Use the filter-enabled GetAllAsync
        var genres = await genreRepository.GetAllAsync(g => ids.Contains(g.Id));

        // Convert entities to DTOs
        return genres.Select(g => g.ToDto()).ToList();
    }

    public async Task<GenreDto> GetGenreByIdAsync(int id)
    {
        var genre = await genreRepository.GetByIdAsync(id);
        return genre.ToDto();
    }
}