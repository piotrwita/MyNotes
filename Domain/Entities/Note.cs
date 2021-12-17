namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public NoteDetail Detail { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
