using MediatR;

namespace Notes.Application.Notes.Command.CreateNote
{
    public class CreateNoteCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
