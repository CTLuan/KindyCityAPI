using System.ComponentModel.DataAnnotations;

namespace KindyCity.Domain.Entites
{
    public class Service
    {
        [Key]
        public Guid ServiceId { get; set; }
        [MaxLength(128)]
        public string ServiceName { get; set; } = string.Empty;
        public int Sort { get; set; }
        public bool Del { get; set; }
    }
}
