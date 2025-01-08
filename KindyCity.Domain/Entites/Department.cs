using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        [MaxLength(255)]
        public string DepartmentName { get; set; } = string.Empty;
        [ForeignKey(nameof(LocationId))]
        public Guid LocationId { get; set; }
        public bool Del { get; set; }
        public virtual Location? Location { get; set; }
    }
}
