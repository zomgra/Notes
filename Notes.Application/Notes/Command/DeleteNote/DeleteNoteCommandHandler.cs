using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Command.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private INoteDbContext _context;

        public DeleteNoteCommandHandler(INoteDbContext context)
        {
            _context = context;
        }

        async Task<Unit> IRequestHandler<DeleteNoteCommand, Unit>.Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == request.NoteId);
            if (entity == null) throw new Exception($"{nameof(entity)} is null or not found");
            _context.Notes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
