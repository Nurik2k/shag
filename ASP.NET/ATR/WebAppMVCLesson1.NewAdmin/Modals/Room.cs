namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public bool IsAvalible { get; set; } = true;
        public int RoomNumber { get; set; }
        public int CategoryId { get; set; }
        public string MainPicturePath { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<RoomProperty> RoomProperties { get;set; }
    }
}
