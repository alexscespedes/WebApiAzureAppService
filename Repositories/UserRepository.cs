
using Microsoft.EntityFrameworkCore;

namespace WebApiAzureAppService;

public class UserRepository : IUserRepository
{   
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync() =>
        await _context.Users
            .AsNoTracking()
            .OrderBy(u => u.Id)
            .Select(u => new UserDto(
                u.Id, u.FullName, u.Email,
                u.Role, u.IsActive, u.CreatedAt))
            .ToListAsync();
    

    public async Task<UserDto?> GetByIdAsync(int id) =>
        await _context.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .Select(u => new UserDto(
                u.Id, u.FullName, u.Email,
                u.Role, u.IsActive, u.CreatedAt))
            .FirstOrDefaultAsync();
}