using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaReservasLibros.Domain.Models;

namespace SistemaReservasLibros.Infra.Data.Configurations
{
    public class ReservationBookModelConfiguration : IEntityTypeConfiguration<ReservationBook>
    {
        public void Configure(EntityTypeBuilder<ReservationBook> builder)
        {
            builder.ToTable("ReservasLibros");

            builder.HasKey(reservationBook => new { reservationBook.ReservationId, reservationBook.BookId });

            builder.Property(reservationBook => reservationBook.BookId)
                .HasColumnName("IdLibro")
                .IsRequired();

            builder.Property(reservationBook => reservationBook.ReservationId)
                .HasColumnName("IdReserva")
                .IsRequired();

            builder.HasOne(reservationBook => reservationBook.Book)
                .WithMany(book => book.ReservationBooks)
                .HasForeignKey(reservationBook => reservationBook.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(reservationBook => reservationBook.Reservation)
                .WithMany(reservation => reservation.ReservationBooks)
                .HasForeignKey(reservationBook => reservationBook.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
