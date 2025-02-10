﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Models.Response
{
    public class EmployeeResponseDto
    {
        public Guid EmployeeId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
