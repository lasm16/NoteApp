using Microsoft.EntityFrameworkCore;

namespace DAL
{
    internal class NoteRepository(AppContext context) : INoteRepository

    {
        public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
        {
            note.Created = DateTime.UtcNow;
            await context.Notes.AddAsync(note, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Notes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
        {
            note.Updated = DateTime.UtcNow;
            context.Notes.Update(note);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
        {
            context.Notes.Remove(note);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
