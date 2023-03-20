namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Room> Rooms { get; set;}
    }
}
