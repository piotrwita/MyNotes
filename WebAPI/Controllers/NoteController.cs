using Application.Dto.Note;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService =
                noteService ?? throw new ArgumentNullException(nameof(noteService));
        }

        [SwaggerOperation(Summary = "Retrieves all notes")]
        [HttpGet]
        public IActionResult Get()
        {
            var notes = _noteService.GetAllNotes();
            return Ok(notes);
        }

        [SwaggerOperation(Summary = "Retrieves a specific notes by keyword")]
        [HttpGet("Search/{keyword}")]
        public IActionResult Search(string keyword)
        {
            var notes = _noteService.SearchByKeyword(keyword);
            return Ok(notes);
        }

        [SwaggerOperation(Summary = "Retrieves a specyfic note by unique id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = _noteService.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [SwaggerOperation(Summary = "Create a new note")]
        [HttpPost]
        public IActionResult Create(CreateNoteDto newNote)
        {
            var note = _noteService.AddNewNote(newNote);
            return Created($"api/notes/{note.Id}", note);
        }

        [SwaggerOperation(Summary = "Update a existing note")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateNoteDto updateNote)
        {
            _noteService.UpdateNote(id, updateNote);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specific note")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.Delete(id);
            return NoContent();
        }
    }
}
