using Todolist.Models;

namespace TodoList.Domain.Interface
{
    public interface ITodoRepository
    {
        IEnumerable<ToDo> GetAll();
        Task<ToDo> GetByIdAsync(int id);
        ToDo Add(ToDo toDo);
        ToDo Update(ToDo toDo);
        bool Remove(int id);
    }
}
