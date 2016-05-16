using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Azure
{
    public class AzureAuthenticator
    {
        public static string GetToken(AzurePrincipal principal)
        {
            var authenticationContext = new AuthenticationContext($"https://login.windows.net/{principal.TenantId}");
            var credential = new ClientCredential(clientId: principal.PrincipalId, clientSecret: principal.PrincipalSecret);
            var result = authenticationContext.AcquireTokenAsync(resource: "https://management.core.windows.net/", clientCredential: credential);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            string token = result.Result.AccessToken;

            return token;
        }
    }
}
