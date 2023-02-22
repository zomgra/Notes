using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class NotesListDto
    {
        public List<NoteVm> Notes { get; set; }
    }
}
