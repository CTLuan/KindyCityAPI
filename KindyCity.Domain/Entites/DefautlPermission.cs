using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class DefautlPermission
    {
        [Key]
        public Guid DefautlPermissionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public Guid PositionId { get; set; }
        [ForeignKey(nameof(OperationId))]
        public Guid OperationId { get; set; }
        public Position? Position { get; set; }
        public Operation? Operation { get; set; }
    }
}
