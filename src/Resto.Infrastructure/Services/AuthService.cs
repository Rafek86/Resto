using Microsoft.AspNetCore.Identity;
using Resto.Domain.Models.Identity;
using Resto.Infrastructure.Data;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.DTOs;
using Resto.Domain.Email;   
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Resto.Application.Common.Exceptions;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Resto.Domain.Enums;

namespace Resto.Infrastructure.Services
{
    public class AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtProvider jwtProvider,
        ILogger<AuthService> logger,
        IEmailSender emailSender,
        IHttpContextAccessor httpContextAccessor,
        ApplicationDbContext context) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly ILogger<AuthService> _logger = logger;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ApplicationDbContext _context = context;


        public async Task<AuthResponse> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            if (await _userManager.FindByEmailAsync(email) is not { } user)
                throw new NotFoundException("Email", $"{email}");

            var result = await _signInManager.PasswordSignInAsync(user, password, false, true);

            if (result.Succeeded)
            {
                var (userRoles, userPermissions) = await GetUserRolesAndPermissions(user, cancellationToken);

                var (token, expiresIn) = _jwtProvider.GenerateToken(user, userRoles, userPermissions);
              
                await _userManager.UpdateAsync(user);

                var response = new AuthResponse(user.Id, user.Email, token, expiresIn);

                return response;
            }

          throw new InvalidOperationException("Invalid login attempt.");
        }

        public async Task RegisterAsync(RegisterRequset request, CancellationToken cancellationToken = default)
        {
            var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);

            if(emailIsExists)
                throw new ConflictException("Email already exists.");
           
            var user =Customer.Create($"{request.FirstName} {request.LastName}", request.Email);
          
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code =WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                await SendConfirmationEmail(user, code);
            }
            else
            {
                throw new InvalidOperationException("User registration failed.");
            }
        }

        public async Task ConfirmEmailAsync(ConfirmEmailRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException("User", request.UserId);


            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user,nameof(UserRole.Customer));
                return;
            }

            if (!result.Succeeded)
                throw new InvalidOperationException("Email confirmation failed.");
        }

        public async Task SendResetPassowrdCodeAsync(string email)
        {
            if (await _userManager.FindByEmailAsync(email) is not { } user)
                return;

            if (!user.EmailConfirmed)
               throw new UnauthorizedAccessException("Email not confirmed.");

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            await SendResetPasswordEmail(user, code);

            return;
        }

        public async Task ResetPasswordAsync(Application.DTOs.ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !user.EmailConfirmed)
               throw new NotFoundException("User", request.Email);

            IdentityResult result;

            try
            {
                var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
                result = await _userManager.ResetPasswordAsync(user, code, request.NewPassword);
            }
            catch (FormatException)
            {
                result = IdentityResult.Failed(_userManager.ErrorDescriber.InvalidToken());
            }
            if (result.Succeeded)
            {
                return;
            }
        }

        private async Task SendConfirmationEmail(ApplicationUser user, string code)
        {
            var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin.ToString();

            var confirmationLink = $"{origin}/auth/emailConfirmation?userId={Uri.EscapeDataString(user.Id)}&code={Uri.EscapeDataString(code)}";

            var templateModel = new Dictionary<string, string>
             {
                 { "{{UserName}}", user.UserName},
                 { "{{LoginPageLink}}", $"{origin}/auth/login" },
                 { "{{CompanyName}}", "GourmetBites" } 
             };

            var emailBody = EmailBuilder.GenerateEmailBody("EmailConfirmation", templateModel);

            await _emailSender.SendEmailAsync(user.Email!, "Confirm Your Email Address", emailBody);
        }

        private async Task SendResetPasswordEmail(ApplicationUser user, string code)
        {
            var origin = _httpContextAccessor.HttpContext?.Request.Headers.Origin.ToString();

            var resetLink = $"{origin}/auth/forgetPassword?email={Uri.EscapeDataString(user.Email!)}&code={Uri.EscapeDataString(code)}";

            var templateModel = new Dictionary<string, string>
             {
                 { "{{CustomerName}}", user.UserName }, 
                 { "{{RestaurantName}}", "Resto Delicious" },
                 { "{{ResetLink}}", resetLink },
                 { "{{ExpirationHours}}", "2" } 
             };

            var emailBody = EmailBuilder.GenerateEmailBody("PasswordReset", templateModel);

            await _emailSender.SendEmailAsync(user.Email!, "Reset Your Password", emailBody);
        }


        private async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetUserRolesAndPermissions(ApplicationUser user, CancellationToken cancellationToken)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var userPermissions = await (from r in _context.Roles
                                         join p in _context.RoleClaims
                                         on r.Id equals p.RoleId
                                         where userRoles.Contains(r.Name!)
                                         select p.ClaimValue!)
                                         .Distinct()
                                         .ToListAsync(cancellationToken);

            return (userRoles, userPermissions);
        }

    }
}