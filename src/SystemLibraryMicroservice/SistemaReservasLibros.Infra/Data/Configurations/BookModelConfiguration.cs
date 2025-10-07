using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaReservasLibros.Domain.Models;

namespace SistemaReservasLibros.Infra.Data.Configurations
{
    public class BookModelConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Libros");

            builder.HasKey(book => book.Id);

            builder.Property(book => book.Id)
                .HasColumnName("IdLibro")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(book => book.Title)
                .HasColumnName("Titulo")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(book => book.Stock)
                .HasColumnName("Existencia")
                .IsRequired();

            builder.Property(book => book.CreatedAt)
                .HasColumnName("FechaCreacion")
                .IsRequired();

            builder.Property(book => book.Autor)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasMany(book => book.ReservationBooks)
                .WithOne(reservationBook => reservationBook.Book)
                .HasForeignKey(reservationBook => reservationBook.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
