using KindyCity.Domain.Enums;
using KindyCity.Shared.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KindyCity.Domain.Entites;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace KindyCity.Application.Commands.EmployeeCommand.Create
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public IFormFile?  Avatar { get; set; } 
        public int Status { get; set; } = 1;
        public DateTime LastSignInTime { get; set; }
        [Key, ForeignKey(nameof(Employee))]
        public string EmployeeCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int Sex { get; set; } = 1;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Skype { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; }
        public string CitizenId { get; set; } = string.Empty;
        public DateTime CitizenIDIssuedDate { get; set; }
        [MaxLength]
        public string CitizenIDIssuedPlace { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public DateTime PassportIssuedDate { get; set; }
        public DateTime PassportIssuedEnd { get; set; }
        [MaxLength]
        public string PassportIssuedPlace { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Nationlity { get; set; } = string.Empty;
        public NationalityStatus IsVietnamese { get; set; }
        public Guid EthnicityId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string PlaceOfOrigin { get; set; } = string.Empty;
        public string CurrentAddress { get; set; } = string.Empty;
        public Guid ResidenceProvinceId { get; set; }
        public Guid ResidenceDistrictId { get; set; }
        public Guid ResidenceWardId { get; set; }
        public Guid ResidenceStreetId { get; set; }
        public string Province { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public WorkingStatus WorkingStatus { get; set; }
        public string EmergencyContactPersonName { get; set; } = string.Empty;
        public string EmergencyContactPersonPhone { get; set; } = string.Empty;
        public Guid EmployeeEducationId { get; set; }
        public string SchoolName { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid CreateBy { get; set; }

        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
