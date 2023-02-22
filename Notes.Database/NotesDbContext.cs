using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Database
{
    public class NotesDbContext : DbContext, INoteDbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasKey(n=>n.NoteId);
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
