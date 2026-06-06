namespace WebApiAzureAppService;

public record UserDto(
    int Id,
    string FullName,
    string Email,
    string Role,
    bool IsActive,
    DateTime CreatedAt
);