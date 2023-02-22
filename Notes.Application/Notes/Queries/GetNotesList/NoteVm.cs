using AutoMapper;
using Notes.Application.Common.Mapping;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNotesList
{
    public class NoteVm : IMapWith<Note>
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteVm>()
                .ForMember(t => t.NoteId, n => n.MapFrom(t => t.NoteId))
                .ForMember(t=>t.Title, n=>n.MapFrom(t=>t.Title))
                .ForMember(t => t.Description, n => n.MapFrom(t => t.Description))
                .ForMember(t => t.DateTime, n => n.MapFrom(n => n.LastChangeDate.ToString("G")));
        }
    }
}
