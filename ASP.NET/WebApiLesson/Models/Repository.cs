namespace WebApiLesson.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reservation> items;
        public Repository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation>()
            {
                new Reservation()
                {
                    Id = 1,
                    Name = "Ankit",
                    StartLocation="New York",
                    EndLocation="Beijing",
                },
                new Reservation()
                {
                    Id = 2,
                    Name = "Bobby",
                    StartLocation="New Jersey",
                    EndLocation="Boston",
                },
                new Reservation()
                {
                    Id = 3,
                    Name = "Jacky",
                    StartLocation="London",
                    EndLocation="Pariss",
                },
            }.ForEach(r => AddReservation(r));
        }
        public Reservation this[int Id] => items.ContainsKey(Id) ? items[Id] : null;
        public IEnumerable<Reservation> Reservations => items.Values;
        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; }
                reservation.Id = key;
            }
            items[reservation.Id] = reservation;
            return reservation;
        }
        public void DeleteReservation(int Id) => items.Remove(Id);
        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
    }
}
    