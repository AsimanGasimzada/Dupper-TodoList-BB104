using TodoListApp.Models.Common;

namespace TodoListApp.Models;
public class TodoItem : BaseEntity
{
    public TodoItem(string title, bool isCompleted = false)
    {
        Title = title;
        IsCompleted = isCompleted;
    }

    public TodoItem()
    {
        
    }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; } = false;

    public override string ToString()
    {
        return $"{Id}. {Title}  {IsCompleted}";
    }
}
