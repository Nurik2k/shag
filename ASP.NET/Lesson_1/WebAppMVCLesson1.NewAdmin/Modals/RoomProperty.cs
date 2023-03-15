namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class RoomProperty
    {
        public int RoomPropertyId { get; set; }
        public string Name { get; set; }

        public ICollection<Room> Rooms { get;set; }
    }
}
