using KindyCity.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KindyCity.Domain.Entites
{
    public class EmployeeInfo
    {
        [Key, ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }
        [MaxLength(10)]
        public string EmployeeCode { get; set; } = string.Empty;
        [MaxLength(255)]
        public string FullName { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public Sex Sex { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Facebook { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Skype { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        [MaxLength(12)]
        public string CitizenId { get; set; } = string.Empty;
        public DateTime CitizenIDIssuedDate { get; set; }
        [MaxLength]
        public string CitizenIDIssuedPlace { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Passport { get; set; } = string.Empty;
        public DateTime PassportIssuedDate { get; set; }
        public DateTime PassportIssuedEnd { get; set; }
        [MaxLength]
        public string PassportIssuedPlace { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Country { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Nationlity { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public NationalityStatus IsVietnamese { get; set; }
        [ForeignKey(nameof(EthnicityId))]
        public Guid EthnicityId { get; set; }
        [Column(TypeName = "tinyint")]
        public MaritalStatus MaritalStatus { get; set; }
        [MaxLength(255)]
        public string PlaceOfOrigin { get; set; } = string.Empty;
        [MaxLength(255)]
        public string CurrentAddress { get; set; } = string.Empty;
        [ForeignKey(nameof(ResidenceProvinceId))]
        public Guid ResidenceProvinceId { get; set; }
        [ForeignKey(nameof(ResidenceDistrictId))]
        public Guid ResidenceDistrictId { get; set; }
        [ForeignKey(nameof(ResidenceWardId))]
        public Guid ResidenceWardId { get; set; }
        [ForeignKey(nameof(ResidenceStreetId))]
        public Guid ResidenceStreetId { get; set; }
        [MaxLength(128)]
        public string Province { get; set; } = string.Empty;
        [MaxLength(128)]
        public string District { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Ward { get; set; } = string.Empty;
        [MaxLength(128)]
        public string Street { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public WorkingStatus WorkingStatus { get; set; }
        [MaxLength(128)]
        public string EmergencyContactPersonName { get; set; } = string.Empty;
        [MaxLength(128)]
        public string EmergencyContactPersonPhone { get; set; } = string.Empty;
        [MaxLength(128)]
        public string EmergencyContactRelationship { get; set; } = string.Empty;
        public virtual Employee? Employee { get; set; }
        public virtual EthnicityCategory? EthnicityCategories { get; set; }
        public virtual ProvinceCategory? ProvinceCategories { get; set; }
        public virtual DistrictCategory? DistrictCategories { get; set; }
        public virtual WardCategory? WardCategories { get; set; }
        public virtual StreetCategory? StreetCategories { get; set; }

    }
}
