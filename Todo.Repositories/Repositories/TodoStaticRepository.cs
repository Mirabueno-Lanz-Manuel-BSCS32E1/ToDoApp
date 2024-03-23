using Todolist.Models;
using TodoList.Domain.Interface;

namespace Todolist.Repositories
{
    public class TodoStaticRepository : ITodoRepository
    {
        private static List<ToDo> todoList;
        public TodoStaticRepository()
        {
            todoList =
            [
                new ToDo
                {
                    CategoryId = "1",
                    Description = "Test",
                    DueDate = DateTime.Now,
                    Id = 1,
                    StatusId = "1",
                },
            ];
        }
        public ToDo Add(ToDo toDo)
        {
            todoList.Add(toDo);
            return toDo;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return todoList;
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
