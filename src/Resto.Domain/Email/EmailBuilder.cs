
namespace Resto.Domain.Email;

public static class EmailBuilder
{
    public static string GenerateEmailBody(string template, Dictionary<string, string> templateModel)
    {
        var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", $"{template}.html");
        if (!File.Exists(templatePath))
            throw new FileNotFoundException($"Email template '{template}.html' not found at path: {templatePath}");

        var body = File.ReadAllText(templatePath);

        foreach (var item in templateModel)
        {
            body = body.Replace(item.Key, item.Value);
        }

        return body;
    }
}
