using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Interfaces
{
    public interface INoteDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
