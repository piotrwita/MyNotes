using Application.Dto.Note;

namespace Application.Interfaces
{
    public interface INoteService
    {
        ListNotesDto GetAllNotes();
        ListNotesDto SearchByKeyword(string keyword);
        NoteDto GetById(int id);
        NoteDto AddNewNote(CreateNoteDto newNote);
        void UpdateNote(int id, UpdateNoteDto note);
        void Delete(int id);

    }
}
