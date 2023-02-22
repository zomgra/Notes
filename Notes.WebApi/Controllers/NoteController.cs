using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Command.CreateNote;
using Notes.Application.Notes.Command.DeleteNote;
using Notes.Application.Notes.Command.UpdateNote;
using Notes.Application.Notes.Queries.GetNotesList;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<List<NoteVm>> GetAllNotes()
        {
            var query = new GetNotesListQuery();
        var res = await Mediator.Send(query);
            return res.Notes;
        }

        [HttpPost]
        public async void Create([FromBody] CreateNoteCommand value)
        {
            await Mediator.Send(value);
        }

        [HttpPut]
        public async void Update([FromBody]UpdateNoteCommand value)
        {
            await Mediator.Send(value);
        }

        [HttpDelete("{id}")]
        public async void DeleteNote(int id)
        {
            var command = new DeleteNoteCommand() { NoteId = id };
            await Mediator.Send(command);
        }
    }
}
