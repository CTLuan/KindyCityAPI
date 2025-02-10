using KindyCity.Application.Models.Response;
using KindyCity.Shared.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Application.Queries.Auth
{
    public class RefreshTokenQuery : IRequest<ApiResponse<RefreshTokenResponse>>
    {
        public Guid DeviceId { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
