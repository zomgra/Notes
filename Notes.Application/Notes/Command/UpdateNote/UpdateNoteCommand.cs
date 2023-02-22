using MediatR;

namespace Notes.Application.Notes.Command.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
