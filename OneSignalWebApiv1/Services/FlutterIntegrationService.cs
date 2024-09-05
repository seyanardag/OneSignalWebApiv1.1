using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace OneSignalWebApiv1.Services
{
    public class FlutterIntegrationService
    {
       
        public string GetEmail (string emailWithCode)
        {            
            var email = string.Empty;
            string[] parts = emailWithCode.Split(new[] { ",/" }, StringSplitOptions.TrimEntries);

            if (parts.Length == 2)
            {
                email = parts[0];                              
            }

            return email;
        }

        public string GetEmailCode(string emailWithCode)
        { 
            var emailCode = string.Empty;
            string[] parts = emailWithCode.Split(new[] { ",/" }, StringSplitOptions.TrimEntries);

            if (parts.Length == 2)
            {               
                emailCode = parts[1];
            }

            return emailCode;
        }






    }
}
