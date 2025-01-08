using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class WardCategory
    {
        [Key]
        public Guid WardCategoryId { get; set; }
        [MaxLength(20)]
        public string WardName { get; set; } = string.Empty;
        //[ForeignKey(nameof(StreetCategoryId))]
        //public Guid StreetCategoryId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        //public virtual StreetCategory? StreetCategory { get; set; }
        public virtual EmployeeInfo? EmployeeInfo { get; set; }
    }
}
