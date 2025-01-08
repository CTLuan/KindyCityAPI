using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class Operation
    {
        [Key]
        public Guid OperationId { get; set; }
        [MaxLength(255)]
        public string OperationName { get; set; } = string.Empty;
        [ForeignKey(nameof(FeatureId))]
        public Guid FeatureId { get; set; }
        public Feature? Feature { get; set; }
    }
}
