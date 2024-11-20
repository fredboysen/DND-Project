using System.Text.Json;
using BookTradingHub.Domain.Models;

namespace BookTradingHub.FileStorage;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer dataContainer = new();
    public List<User> Users { get { LoadData(); return dataContainer.Users; } }
    public List<Todo> Todos { get { LoadData(); return dataContainer.Todos; } }

    public async Task SaveChangesAsync()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
        };

        var data = JsonSerializer.Serialize(dataContainer, options);
        await File.WriteAllTextAsync(filePath, data);
    }

    public void LoadData()
    {
        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Users = [],
                Todos = []
            };
            return;
        }
        var content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content) ?? new();
    }

}