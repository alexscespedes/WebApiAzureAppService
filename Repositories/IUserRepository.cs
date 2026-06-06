namespace WebApiAzureAppService;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
}