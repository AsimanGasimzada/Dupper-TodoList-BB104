using TodoListApp.Models;
using TodoListApp.Repositories.Abstractions;
using TodoListApp.Repositories.Implementations;

namespace TodoListApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ITodoRepository repository = new TodoRepository("Server=DESKTOP-U2HDDUL;Database=TodoDb;Trusted_connection=true");


            //repository.Add(new("Bu gun kod yazacam"));

            //TodoItem item = new()
            //{
            //    Title = "Salamm",
            //    IsCompleted = false,
            //    Id = 1
            //};


            //Console.WriteLine(item.Title);
            //repository.Update(item);


            //repository.Delete(1);


            await repository.AddAsync(new("Ise getmeliyem"));
            await repository.AddAsync(new("Eve getmeliyem"));
            await repository.AddAsync(new("Task yazmaliyam"));
            await repository.AddAsync(new("Yemek yemeliyem"));
            await repository.AddAsync(new("Ise getmeliyem vol 2"));
            var list = await repository.GetAllAsync();

            list.ForEach(item => Console.WriteLine(item));



            var listItem = await repository.GetByIdAsync(7);

            Console.WriteLine(listItem);
        }
    }
}
