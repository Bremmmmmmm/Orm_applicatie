using Interface.Dtos;

namespace Interface.Interface;

public interface IAuthorContainer
{
    Task<AuthorDto> GetAuthorByIdAsync(int id);
}