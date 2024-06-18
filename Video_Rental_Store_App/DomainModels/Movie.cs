namespace DomainModels
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
    }
}
