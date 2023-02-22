using MediatR;
using Notes.Domain;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Command.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand,Unit>
    {
        private readonly INoteDbContext _context;

        public CreateNoteCommandHandler(INoteDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = new Note() { DateCreation = DateTime.UtcNow,LastChangeDate = DateTime.UtcNow, Description = request.Description, Title = request.Title};
            await _context.Notes.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
