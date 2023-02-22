using Notes.Database;
using Notes.Domain;

namespace Notes.WebApi
{
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            for (int i = 0; i < 4; i++)
            {
                var note = new Note { DateCreation = DateTime.UtcNow, Title = $"Is a test note #{i}", Description = $"Test infomation for note #{i}" };
                context.Notes.Add(note);
            }
            context.SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
