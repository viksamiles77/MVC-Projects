namespace DomainModels
{
    public class Rental : BaseEntity
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime? RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public Rental(int userId, int movieId)
        {
            UserId = userId;
            MovieId = movieId;
            RentedOn = DateTime.Now;
        }
        public void Return()
        {
            ReturnedOn = DateTime.Now;
        }
    }
}
