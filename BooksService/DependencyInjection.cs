using Books.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BooksService;

public static class DependencyInjection
{
    public static IServiceCollection AddBooksService(this IServiceCollection services, string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddDbContext<BooksDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}