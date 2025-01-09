using DataAccess.Entitys;
using Interface.Dtos;
using Interface.Interface;

namespace Logic.Container;

public class AuthorContainer(IRepository<Author> authorRepository) : IAuthorContainer
{
    public async Task<AuthorDto> GetAuthorByIdAsync(int id)
    {
        var author = await authorRepository.GetByIdAsync(id, a => a.Books);
        return author.ToDto();
    }
}