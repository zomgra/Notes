using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Command.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INoteDbContext _context;

        public UpdateNoteCommandHandler(INoteDbContext context)
        {
            _context = context;
        }

        async Task<Unit> IRequestHandler<UpdateNoteCommand, Unit>.Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == request.NoteId, cancellationToken);
            if (entity == null) throw new Exception($"{nameof(entity)} is empty or not found");
            entity.ChangeDate();
            entity.Title = request.Title;
            entity.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
