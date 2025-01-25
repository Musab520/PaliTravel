using Microsoft.EntityFrameworkCore;
using System.IO;
using Infrastructure;
using Microsoft.Extensions.Logging;

public class DatabaseSeeder
{
    private readonly Context _dbContext;
    private readonly ILogger<DatabaseSeeder> _logger;
    
    public DatabaseSeeder(Context dbContext, ILogger<DatabaseSeeder> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task SeedDataAsync()
    {
        var scriptFiles = new[]
        {
            "../Infrastructure/seed/seed1.sql",
            "../Infrastructure/seed/seed2.sql",
            "../Infrastructure/seed/seed3.sql"
        };

        foreach (var scriptFile in scriptFiles)
        {
            try
            {
                var sql = await File.ReadAllTextAsync(scriptFile);
                await _dbContext.Database.ExecuteSqlRawAsync(sql);
                _logger.LogInformation($"Successfully executed script: {scriptFile}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error executing script {scriptFile}: {ex.Message}");
            }
        }
    }
}