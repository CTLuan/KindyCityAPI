using KindyCity.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace KindyCity.Domain.Entites
{
    public class Menu
    {
        [Key]
        public Guid MenuId { get; set; }
        public Guid ServiceId { get; set; }
        public MenuCode MenuCode { get; set; }
        [MaxLength(255)]
        public string MenuName { get; set; } = string.Empty;
        public bool Del { get; set; }
        public Service? Service { get; set; }
    }
}
