namespace Domain.Entities
{
    public class NoteDetail
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public int NoteId { get; set; }
        public Note Note { get; set; }

    }
}
