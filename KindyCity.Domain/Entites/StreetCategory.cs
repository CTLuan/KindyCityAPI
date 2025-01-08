using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class StreetCategory
    {
        [Key]
        public Guid StreetCategoryId { get; set; }
        [MaxLength(20)]
        public string StreetCategoryName { get; set; } = string.Empty;
        //[ForeignKey(nameof(DistrictCategoryId))]
        //public Guid DistrictCategoryId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        //public virtual DistrictCategory? DistrictCategories { get; set; }
        public virtual EmployeeInfo? EmployeeInfo { get; set; }
    }
}
