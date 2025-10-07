using SistemaReservasLibros.Domain.Abstractions;

namespace SistemaReservasLibros.Domain.Models
{
    public class Book:DomainEntity<int>
    {
        public string Title { get; private set; } = default!;

        public string Autor { get; private set; } = default!;

        public int Stock { get; private set; }

        public ICollection<ReservationBook> ReservationBooks { get; private set; } = [];

        public static Book Create(
            string title,
            string autor,
            int stock)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(stock);
            ArgumentNullException.ThrowIfNull(stock, nameof(stock));
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(autor);

            return new Book
            {
                Title = title,
                Autor = autor,
                Stock = stock
            };
        }

        public void Update(
            string? title,
            string? author,
            int? stock
            )
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(stock ?? Stock);
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(author);

            Title = title ?? Title;
            Autor = author ?? Autor;
            Stock = stock ?? Stock;
        }

        public void DescontarStock()
        {
            Stock -= 1;
        }
    }
}
