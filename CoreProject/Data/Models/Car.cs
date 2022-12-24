namespace CoreProject.Data.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Img { get; set; }
        public uint Price { get; set; }
        public bool IsFavourite { get; set; }
        public bool IsAvaiable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
