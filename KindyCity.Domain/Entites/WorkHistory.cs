using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class WorkHistory
    {
        [Key]
        public Guid WorkHistoryId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }

        public Guid CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey(nameof(PositionId))]
        public Guid PositionId { get; set; }
        public bool Active { get; set; }
        public bool Del { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Position? Position { get; set; }
    }
}
