using KindyCity.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [MaxLength]
        public string PasswordHash { get; set; } = string.Empty;
        [MaxLength(128)]
        public string PasswordSalt { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        [MaxLength(255)]
        public string Avatar { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Absent;
        public DateTime LastSignInTime { get; set; }
        public virtual EmployeeInfo? EmployeeInfo { get; set; }
    }
}
