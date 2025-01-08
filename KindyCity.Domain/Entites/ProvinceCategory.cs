using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class ProvinceCategory
    {
        [Key]
        public Guid ProvinceCategoryId { get; set; }
        [MaxLength(20)]
        public string ProvinceName { get; set; } = string.Empty;
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public virtual EmployeeInfo? EmployeeInfo { get; set; }

    }
}
