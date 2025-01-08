using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class EmployeeEducation
    {
        [Key]
        public Guid EmployeeEducationId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        [MaxLength(255)]
        public string SchoolName { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Degree { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Major { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime CreateOn { get; set; }

        public Guid ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }
        public bool Del { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
