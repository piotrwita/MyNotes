using Application.Dto.Category;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService =
                categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [SwaggerOperation(Summary = "Retrieves all categories")]
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [SwaggerOperation(Summary = "Retrieves a specyfic category by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [SwaggerOperation(Summary = "Create a new category")]
        [HttpPost]
        public IActionResult Create(CreateCategoryDto newCategory)
        {
            var category = _categoryService.AddNewCategory(newCategory);
            return Created($"api/categories/{category.Id}", category);
        }

        [SwaggerOperation(Summary = "Update a existing category")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateCategoryDto updateCategory)
        {
            _categoryService.UpdateCategory(id, updateCategory);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific category")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
