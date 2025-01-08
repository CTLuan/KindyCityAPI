using KindyCity.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class Position
    {
        [Key]
        public Guid PositionId { get; set; }
        [Required]
        [ForeignKey(nameof(DepartmentId))]
        public Guid DepartmentId { get; set; }
        public PositionCode PositionCode { get; set; }
        [MaxLength(255)]
        public string PositionName { get; set; } = string.Empty;
        public bool Del { get; set; }
        public virtual Department? Department { get; set; }
    }
}
