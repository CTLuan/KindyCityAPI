using KindyCity.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace KindyCity.Domain.Entites
{
    public class EmployeeRefreshToken
    {
        [Key]
        public Guid RefreshTokenId { get; set; } = Guid.NewGuid();
        public Guid DeviceId { get; set; } = Guid.NewGuid();
        public string DeviceInfo { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsRevoked { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
