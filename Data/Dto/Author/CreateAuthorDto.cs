namespace BlogApplication.Dto.Author;

public record class CreateAuthorDto
(Guid Id,
        string Name,
        string Bio);