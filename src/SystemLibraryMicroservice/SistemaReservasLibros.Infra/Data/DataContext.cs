using Microsoft.EntityFrameworkCore;
using SistemaReservasLibros.Domain.Models;


namespace SistemaReservasLibros.Infra.Data
{
    public class DataContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationBook> ReservationBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
