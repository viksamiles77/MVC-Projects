using DomainModels.Enums;

namespace DomainModels
{
    public class Cast : BaseEntity
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public PartEnum Part { get; set; }
    }
}
