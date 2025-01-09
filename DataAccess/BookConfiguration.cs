using DataAccess.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // Configure primary key
        builder.HasKey(b => b.Id);

        // Configure properties
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(100);

        // Configure relationships
        builder.HasOne(b => b.Author) // Navigation property for the Author
            .WithMany(a => a.Books)   // An Author can have many Books
            .HasForeignKey(b => b.AuthorId) // Foreign key in Book
            .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete
        
        builder.HasMany(b => b.Genres) // Navigation property for Genres
            .WithMany(g => g.Books)    // Navigation property in Genre
            .UsingEntity<BookGenre>(   // Intermediate entity
                j => j.HasOne(bg => bg.Genre)
                    .WithMany(g => g.BookGenres)
                    .HasForeignKey(bg => bg.GenreId),
                j => j.HasOne(bg => bg.Book)
                    .WithMany(b => b.BookGenres)
                    .HasForeignKey(bg => bg.BookId),
                j =>
                {
                    j.HasKey(bg => new { bg.BookId, bg.GenreId }); // Composite key
                    j.ToTable("BookGenres"); // Table name for join entity
                });
    }
}