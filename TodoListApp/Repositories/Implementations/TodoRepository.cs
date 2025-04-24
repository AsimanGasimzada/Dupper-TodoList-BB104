using Dapper;
using Microsoft.Data.SqlClient;
using TodoListApp.Models;
using TodoListApp.Repositories.Abstractions;

namespace TodoListApp.Repositories.Implementations;

public class TodoRepository : ITodoRepository
{
    public string _connectionString { get; private set; }


    public TodoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<int> AddAsync(TodoItem item)
    {
        using var db = new SqlConnection(_connectionString);
        const string sql = "INSERT INTO TodoItems (Title, IsCompleted) VALUES (@Title, @IsCompleted)";
        return await db.ExecuteAsync(sql, item);
    }

    public async Task<int> UpdateAsync(TodoItem item)
    {
        using var db = new SqlConnection(_connectionString);

        var existItem = await db.QuerySingleOrDefaultAsync<TodoItem>(
            "SELECT * FROM TodoItems WHERE Id = @Id", new { item.Id });

        if (existItem is null)
            throw new Exception($"Todo item with ID {item.Id} not found");

        const string sql = "UPDATE TodoItems SET Title = @Title, IsCompleted = @IsCompleted WHERE Id = @Id";
        return await db.ExecuteAsync(sql, item);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using var db = new SqlConnection(_connectionString);
        const string sql = "DELETE FROM TodoItems WHERE Id = @Id";
        return await db.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<TodoItem> GetByIdAsync(int id)
    {
        using var db = new SqlConnection(_connectionString);

        var item = await db.QuerySingleOrDefaultAsync<TodoItem>(
            "SELECT * FROM TodoItems WHERE Id = @Id", new { Id = id });

        if (item is null)
            throw new Exception($"Todo item with ID {id} not found");

        return item;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        using var db = new SqlConnection(_connectionString);

        var items = await db.QueryAsync<TodoItem>("SELECT * FROM TodoItems");

        return items.ToList();
    }
}
