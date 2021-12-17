using Application.Dto;
using Application.Dto.Category;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository
                , IMapper mapper)
        {
            _categoryRepository =
                categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));

            _mapper =
                mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public CategoryDto AddNewCategory(CreateCategoryDto newCategory)
        {
            if (string.IsNullOrEmpty(newCategory.Name))
            {
                throw new Exception("Category can not have an empty name");
            }

            var categoryWithSameName = _categoryRepository.GetAll().SingleOrDefault(x => x.Name == newCategory.Name);
            if (categoryWithSameName != null)
            {
                throw new Exception("Category with the same name already exists");
            }

            var category = _mapper.Map<Category>(newCategory);
            _categoryRepository.Add(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public void UpdateCategory(int id, UpdateCategoryDto category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("Category can not have an empty name");
            }

            var categoryWithSameName = _categoryRepository.GetAll().SingleOrDefault(x => x.Name == category.Name);
            if (categoryWithSameName != null)
            {
                throw new Exception("Category with the same name already exists");
            }

            var existingCategory = _categoryRepository.GetById(id);
            var updatedCategory = _mapper.Map(category, existingCategory);
            _categoryRepository.Update(updatedCategory);
        }

        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);
        }
    }
}
