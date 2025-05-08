using Resto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponse> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);
    Task RegisterAsync(RegisterRequset request, CancellationToken cancellationToken = default);
    Task ConfirmEmailAsync(ConfirmEmailRequest request);
    Task SendResetPassowrdCodeAsync(string email);
    Task ResetPasswordAsync(ResetpasswordRequest request);
}
