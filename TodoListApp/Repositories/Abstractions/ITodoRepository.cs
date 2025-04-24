using TodoListApp.Models;

namespace TodoListApp.Repositories.Abstractions;
public interface ITodoRepository
{
    Task<int> AddAsync(TodoItem item);
    Task<int> UpdateAsync(TodoItem item);
    Task<int> DeleteAsync(int id);
    Task<TodoItem> GetByIdAsync(int id);
    Task<List<TodoItem>> GetAllAsync();
}
