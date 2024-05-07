using BlogApplication.Models;

namespace BlogApplication.Dto.Author;

public record class AuthorDto(
         string Name,
         string Bio,
         IEnumerable<Blog>? Blogs
);
