using Microsoft.EntityFrameworkCore;

namespace WebApiAzureAppService;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Users.AnyAsync()) return;

        var users = new List<User>
        {
            new() { FullName = "Alice Martin", Email = "alice@myapi.dev", Role = "Admin", CreatedAt = DateTime.UtcNow },
            new() { FullName = "Bob Reynolds", Email = "bob@myapi.dev", Role = "Editor", CreatedAt = DateTime.UtcNow },
            new() { FullName = "Carol Simmons", Email = "carol@myapi.dev", Role = "Viewer", CreatedAt = DateTime.UtcNow },
            new() { FullName = "David Chen", Email = "david@myapi.dev", Role = "Editor", CreatedAt = DateTime.UtcNow },
            new() { FullName = "Eva Rodriguez", Email = "eva@myapi.dev", Role = "Viewer", CreatedAt = DateTime.UtcNow }
        };

        context.Users.AddRange(users);
        await context.SaveChangesAsync();

        Console.WriteLine($"[Seeder] ✓ {users.Count} users seeded.");
    }
}