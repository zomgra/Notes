using MediatR;

namespace Notes.Application.Notes.Command.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public int NoteId { get; set; }
    }
}
