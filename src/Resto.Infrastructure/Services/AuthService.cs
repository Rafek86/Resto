namespace Resto.Infrastructure.Services
{
    public class AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IJwtProvider jwtProvider,
        IEmailSender emailSender,
        IHttpContextAccessor httpContextAccessor,
        INotificationService notificationService,
        ILogger<ApplicationUser>logger,
        ApplicationDbContext context) : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly INotificationService _notificationService = notificationService;
        private readonly ILogger<ApplicationUser> _logger = logger;
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

          throw new EmailNotConfirmedException("Email doesn't Confirmed yet");
        }

        public async Task RegisterAsync(RegisterRequset request, CancellationToken cancellationToken = default)
        {
            var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);

            if(emailIsExists)
                throw new ConflictException("Email already exists.");
           
            var user =Customer.Create(request.UserName, request.Email);
          
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code =WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                _logger.LogInformation(code);
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

        public async Task ResetPasswordAsync(ResetpasswordRequest request)
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
                 { "{{UserName}}", user.UserName!},
                 { "{{LoginPageLink}}", $"{origin}/auth/login" },
                 { "{{CompanyName}}", "GourmetBites" } 
            };

            var notification =Notification.Create(
                user.Id,
                $"Please confirm your email by clicking this link: {confirmationLink}",
                NotificationType.Confirmation
            );

            await _notificationService.AddNotificationAsync(notification.Adapt<CreateNotificationCommand>());

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


            var notification = Notification.Create(
                user.Id,
                $"Please reset your password by clicking this link: {resetLink}",
                NotificationType.ResetPassword);

            await _notificationService.AddNotificationAsync(notification.Adapt<CreateNotificationCommand>());

            var emailBody = EmailBuilder.GenerateEmailBody("PasswordReset", templateModel);

            await _emailSender.SendEmailAsync(user.Email!, "Reset Your Password", emailBody);
        }


        private async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetUserRolesAndPermissions(ApplicationUser user, CancellationToken cancellationToken)
        {
            // Step 1: Get Identity roles from ASP.NET Identity
            var identityRoles = await _userManager.GetRolesAsync(user);
            _logger.LogInformation($"Identity roles for user {user.Email}: {string.Join(", ", identityRoles)}");

            // Step 2: Get application-specific roles from your database tables
            var applicationRoles = new List<string>();

            // Check if user is in Customers table
            var isCustomer = await _context.Customers
                .AnyAsync(c => c.Id == user.Id, cancellationToken);

            if (isCustomer)
            {
                applicationRoles.Add("Customer");
                _logger.LogInformation($"User {user.Email} is a Customer based on database record");
            }

            // Check if user is in Staffs table
            var isStaff = await _context.Staffs
                .AnyAsync(s => s.Id == user.Id, cancellationToken);

            if (isStaff)
            {
                applicationRoles.Add("Staff");
                _logger.LogInformation($"User {user.Email} is a Staff member based on database record");
            }

            // Check if user is in Admins table
            var isAdmin = await _context.Admins
                .AnyAsync(a => a.Id == user.Id, cancellationToken);

            if (isAdmin)
            {
                applicationRoles.Add("Admin");
                _logger.LogInformation($"User {user.Email} is an Admin based on database record");
            }

            // Step 3: Combine Identity and application-specific roles
            var combinedRoles = identityRoles.Union(applicationRoles).ToList();

            // Step 4: Get permissions for all roles
            List<string> userPermissions = new List<string>();

            // Get permissions from RoleClaims table for Identity roles
            var identityPermissions = await (from r in _context.Roles
                                             join p in _context.RoleClaims
                                             on r.Id equals p.RoleId
                                             where identityRoles.Contains(r.Name!)
                                             select p.ClaimValue!)
                                           .Distinct()
                                           .ToListAsync(cancellationToken);

            userPermissions.AddRange(identityPermissions.Where(p => p != null));

            foreach (var role in applicationRoles)
            {
                if (Permissions.GetDefaultRolePermissions().TryGetValue(role, out var rolePermissions))
                {
                    userPermissions.AddRange(rolePermissions);
                }
            }

            var distinctPermissions = userPermissions.Distinct().ToList();
            _logger.LogInformation($"Permissions for user {user.Email}: {string.Join(", ", distinctPermissions)}");

            return (combinedRoles, distinctPermissions);
        }

    }
}