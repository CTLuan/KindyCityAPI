using KindyCity.Application.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Queries.Auth
{
    public class ForgotPasswordQuery : IRequest<ForgotPasswordDto>
    {
        public string Email { get; set; } = string.Empty;
    }
}
