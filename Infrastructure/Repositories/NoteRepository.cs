namespace Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly MyNoteContext _context;

        public NoteRepository(MyNoteContext context)
        {
            _context =
                context ?? throw new ArgumentNullException(nameof(context));

        }
        public IQueryable<Note> GetAll()
        {
            return _context.Notes
                .Include(x => x.Detail)
                .Include(x => x.Category);
        }

        public Note GetById(int id)
        {
            return _context.Notes
                .Include(x => x.Detail)
                .Include(x => x.Category)
                .SingleOrDefault(x => x.Id == id);
        }

        public Note Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;   
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void Delete(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

    }
}
