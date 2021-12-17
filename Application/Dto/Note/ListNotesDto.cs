using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Note
{
    public class ListNotesDto
    {
        public int Count { get; set; }  
        public IEnumerable<NoteDto> Notes { get; set; }

    }
}
