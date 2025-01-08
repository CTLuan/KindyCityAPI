using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class EthnicityCategory
    {
        [Key]
        public Guid EthnicityCategoryId { get; set; }
        [MaxLength(20)]
        public string EthnicityName { get; set; } = string.Empty;
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public virtual EmployeeInfo? EmployeeInfo { get; set; }
    }
}
