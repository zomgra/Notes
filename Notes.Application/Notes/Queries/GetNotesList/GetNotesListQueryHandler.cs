using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class GetNotesListQueryHandler : IRequestHandler<GetNotesListQuery, NotesListDto>
    {
        private INoteDbContext _context;
        private IMapper _mapper;

        public GetNotesListQueryHandler(IMapper mapper, INoteDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotesListDto> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            var entitys = await _context.Notes
                .ProjectTo<NoteVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (!entitys.Any()) throw new Exception($"{nameof(entitys)} is empty");
            return new NotesListDto() { Notes = entitys };
        }
    }
}
