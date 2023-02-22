using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;

namespace Notes.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<NotesDbContext>(i => i.UseInMemoryDatabase("Note_DevOnly"));

            services.AddScoped<INoteDbContext>(p =>
                    p.GetService<NotesDbContext>());
            
            return services;
        }
    }
}
