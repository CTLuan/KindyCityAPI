using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Models.Response
{
    public class ForgotPasswordDto
    {
        public Guid EmployeeId { get; set; }
        public string OTP { get; set; } = string.Empty;
    }
}
