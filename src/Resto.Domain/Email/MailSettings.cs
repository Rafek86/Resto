
namespace Resto.Domain.Email
{
    public class MailSettings
    {
        public static string SectionName = "MailSettings";

        public string Host { get; set; } = string.Empty;

        public int Port { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string SenderEmail { get; set; } = string.Empty;

        public string SenderName { get; set; } = string.Empty;
    }
}
