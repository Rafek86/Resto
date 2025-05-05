using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Domain.Email;

public static class EmailBuilder 
{
    public static string GenerateEmailBody(string template,Dictionary<string,string> templateModel)
    {
        var templetPath = $"{Directory.GetCurrentDirectory()}/Templetes/{template}.html";
        var streamReader = new StreamReader(template);
        var body =streamReader.ReadToEnd();
        streamReader.Close();

        foreach (var item in templateModel) {
             body = body.Replace(item.Key, item.Value);  
        }

        return body;
}
}