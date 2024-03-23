using Todolist.Models;

namespace TodoList.Domain.Interface
{

    public interface IStatusRepository
    {
        IEnumerable<Status> GetAll();

    }
}
