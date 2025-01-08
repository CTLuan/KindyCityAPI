using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }
        [MaxLength(255)]
        public string LocationName { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Address { get; set; } = string.Empty;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sort { get; set; }
        public bool Del { get; set; }
    }
}
