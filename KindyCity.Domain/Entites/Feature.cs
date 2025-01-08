using System.ComponentModel.DataAnnotations;

namespace KindyCity.Domain.Entites
{
    public class Feature
    {
        [Key]
        public Guid FeatureId { get; set; }
        [MaxLength(255)]
        public string FeatureName { get; set; } = string.Empty;
        public Guid MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
