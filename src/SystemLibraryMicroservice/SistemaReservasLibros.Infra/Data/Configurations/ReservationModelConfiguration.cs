using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaReservasLibros.Domain.Models;

namespace SistemaReservasLibros.Infra.Data.Configurations
{
    public class ReservationModelConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservas");

            builder.HasKey(reservation => reservation.Id);

            builder.Property(reservation => reservation.Id)
                .HasColumnName("IdReserva")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(reservation => reservation.StartDate)
                .HasColumnName("FechaInicio")
                .IsRequired();

            builder.Property(reservation => reservation.EndDate)
                .HasColumnName("FechaFin")
                .IsRequired();

            builder.Property(reservation => reservation.Status)
                .HasColumnName("Estado")
                .IsRequired();

            builder.Property(reservation => reservation.UserId)
                .HasColumnName("IdUsuario")
                .IsRequired();

            builder.Property(reservation => reservation.CreatedAt)
                .HasColumnName("FechaCreacion")
                .IsRequired();

            //builder.HasOne<AppIdentityUser>()
            //    .WithMany()
            //    .HasForeignKey(reservation => reservation.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(reservation => reservation.ReservationBooks)
                .WithOne(reservationBook => reservationBook.Reservation)
                .HasForeignKey(reservationBook => reservationBook.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
