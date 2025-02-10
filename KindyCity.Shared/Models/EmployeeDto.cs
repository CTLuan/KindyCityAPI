using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Shared.Models
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
    }
}
