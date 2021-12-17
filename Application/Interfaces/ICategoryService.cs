using Application.Dto.Category;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetById(int id);
        CategoryDto AddNewCategory(CreateCategoryDto newCategory);
        void UpdateCategory(int id, UpdateCategoryDto category);
        void Delete(int id);

    }
}
