namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyNoteContext _context;

        public CategoryRepository(MyNoteContext context)
        {
            _context =
                context ?? throw new ArgumentNullException(nameof(context));

        }
        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == id);
        }

        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;   
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

    }
}
