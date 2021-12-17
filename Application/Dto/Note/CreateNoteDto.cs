namespace Application.Dto.Note
{
    public class CreateNoteDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
