using Microsoft.AspNetCore.Http.Features;

namespace WebAPI_example.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reservation> items;
        public Repository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation> {
             new Reservation { Id = 1, Name = "Ankit", StartLocation = "New York", EndLocation = "Beijing" },
             new Reservation { Id = 2, Name = "Bobby", StartLocation = "San-Francisco", EndLocation = "Pekin" },
             new Reservation { Id = 3, Name = "Sam", StartLocation = "London", EndLocation = "Sydney" }
             }.ForEach(r => AddReservation(r));
        }

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;
        public IEnumerable<Reservation> Reservations => items.Values;
        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reservation.Id = key;
            }
            items[reservation.Id] = reservation;
            return reservation;
        }

        public void DeleteReservation(int Id) => items.Remove(Id);
        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
    }
}
