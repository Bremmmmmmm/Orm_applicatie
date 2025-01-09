using DataAccess.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);

        // Configure properties
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        // Configure many-to-many relationship with Books
        builder.HasMany(g => g.Books) // Navigation property for Books
            .WithMany(b => b.Genres)   // Navigation property in Book
            .UsingEntity<BookGenre>(   // Intermediate entity
                j => j.HasOne(bg => bg.Book)
                    .WithMany(b => b.BookGenres)
                    .HasForeignKey(bg => bg.BookId),
                j => j.HasOne(bg => bg.Genre)
                    .WithMany(g => g.BookGenres)
                    .HasForeignKey(bg => bg.GenreId),
                j =>
                {
                    j.HasKey(bg => new { bg.BookId, bg.GenreId }); // Composite key
                    j.ToTable("BookGenres"); // Table name for join entity
                });
    }
}