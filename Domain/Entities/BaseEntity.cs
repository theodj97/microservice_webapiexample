
namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; }
        public bool Habilited { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
