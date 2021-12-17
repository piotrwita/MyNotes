using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category);
        void Update(Category category); 
        void Delete(Category category); 
    }
}
