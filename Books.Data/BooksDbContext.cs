using Microsoft.EntityFrameworkCore;

namespace Books.Data;

public class BooksDbContext(DbContextOptions<BooksDbContext> options) : DbContext(options)
{
	public DbSet<Book> Books => Set<Book>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Book>(entity =>
		{
			entity.ToTable("books");
			entity.HasKey(book => book.Id);
		});
	}
}