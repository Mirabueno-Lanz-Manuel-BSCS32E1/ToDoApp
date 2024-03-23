using Todolist.Models;

namespace TodoList.Domain.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Task<Category> GetByIdAsync(int id);
        Category Add(Category T);
        Category Update(Category T);
        bool Remove(int id);
    }
}
