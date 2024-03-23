using Todolist.Models;
using TodoList.Domain.Interface;

namespace Todolist.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ToDoContext _context;
        public TodoRepository(ToDoContext dbContext)
        {
            _context = dbContext;
        }
        public ToDo Add(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _context.ToDoS.AsEnumerable();
        }

        public Task<ToDo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public ToDo Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
