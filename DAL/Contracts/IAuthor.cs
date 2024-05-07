using BlogApplication.Dto.Author;
using TaskManagement.DAL.Contracts;

namespace BlogApplication;

public interface IAuthor :IBase<AuthorDto,CreateAuthorDto,EditAuthorDto>
{

}
